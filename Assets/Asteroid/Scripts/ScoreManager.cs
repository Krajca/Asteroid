using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    public int Score
    {
        get;
        protected set;
    }

    public int HiScore
    {
        get;
        protected set;
    }

    string hiScore = "hiScore";
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        HiScore = PlayerPrefs.GetInt(hiScore, 0);
        Score = 0;
    }
    
    public void AddScore(int score)
    {
        Score += score;
    }

    public bool SaveIfNewHiScore()
    {
        bool isNewHiScore = false;

        if (Score > HiScore)
        {
            HiScore = Score;
            PlayerPrefs.SetInt(hiScore, HiScore);
            isNewHiScore = true;
        }

        return isNewHiScore;
    }
}
