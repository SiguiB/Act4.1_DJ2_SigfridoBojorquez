using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int mejorScore;
    public int actualScore;

    public int actualLevel = 0;

    public static GameManager singleton;

    void Awake()
    {
       if(singleton == null)
       {
        singleton = this;
       } 
       else if (singleton = this) 
       {
        Destroy(gameObject);
       }
       mejorScore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
        actualLevel++;
        FindObjectOfType<PelotaController>().ResetPelota();
        FindObjectOfType<HelixController>().LoadStage(actualLevel);
        Debug.Log("Has pasado de nivel");
    }

    public void RestartLevel()
    {
        singleton.actualScore = 0;
        FindObjectOfType<PelotaController>().ResetPelota();
        FindObjectOfType<HelixController>().LoadStage(actualLevel);
    }

    public void AgregaScore(int scoreToAdd)
    {
        actualScore += scoreToAdd;

        if(actualScore > mejorScore)
        {
            mejorScore = actualScore;
            PlayerPrefs.SetInt("HighScore", actualScore);
        }
    }
}
