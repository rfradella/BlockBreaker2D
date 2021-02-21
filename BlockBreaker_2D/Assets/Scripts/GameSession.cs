using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range (0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreTex;
    [SerializeField] bool isAutoPlayEnabled = false;

    //Singleton
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount >1)
        {
            //Avoids null reference exception
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreTex.text = "Score: "+ currentScore.ToString();
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreTex.text = "Score: " + currentScore.ToString();
    }

    public void ResetGame()
    {
        //Avoids null reference exception
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
