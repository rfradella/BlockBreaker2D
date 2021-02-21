using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16.0f;
    [SerializeField] float minX = 1f;
    [SerializeField] float minY = 15f;

    GameSession theGameSession;
    Ball theBall;

    private void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, minY);
        transform.position = paddlePos;        
    }
    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
