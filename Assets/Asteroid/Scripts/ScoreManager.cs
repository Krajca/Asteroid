using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.UI
{
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

        string hiScoreID = "hiScore";

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);

            HiScore = PlayerPrefs.GetInt(hiScoreID, 0);
        }

        public void AddScore(int score)
        {
            Score += score;
        }

        public void ClearScore()
        {
            Score = 0;
        }

        public bool SaveIfNewHiScore()
        {
            bool isNewHiScore = false;

            if (Score > HiScore)
            {
                HiScore = Score;
                PlayerPrefs.SetInt(hiScoreID, HiScore);
                isNewHiScore = true;
            }

            ClearScore();
            return isNewHiScore;
        }
    }
}