using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //PRIVATE VARIABLES
    private PlayerShip playerScript;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            score = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void GameOver()
    {
        Debug.Log("EL JUEGO TERMINO");
        score = 0;
    }


    public void addScore()
    {
        instance.score += 1;
    }

    public static int GetScore()
    {
        return instance.score;
    }
}
