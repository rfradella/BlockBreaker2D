using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float RandomFactor;
    bool hasStarted = false;

    //State
    Vector2 paddleToBallVector;

    //Cached component reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    GameSession myGameSession;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myGameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }
        LaunchOnMouseClick();
        
    }

    private void LaunchOnMouseClick()
    {
        if (!hasStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myRigidbody2D.velocity = new Vector2(xPush, yPush);
                hasStarted = true;
            }
        }
    }

    private void LockBallToPaddle()
    {
        hasStarted = false;
        Vector2 paddlePosiion = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        if (!myGameSession.IsAutoPlayEnabled())
        {
            transform.position = paddlePosiion + paddleToBallVector;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f,RandomFactor),
            Random.Range(0f, RandomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }       
    }
}
