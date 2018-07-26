using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidGame.UI
{
    public class GameGUIScript : MonoBehaviour
    {
        public static GameGUIScript instance = null;

        [SerializeField]
        Text score;
        [SerializeField]
        Text hiScore;
        [SerializeField]
        GameObject[] lives;



        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            hiScore.text = ScoreManager.instance.HiScore.ToString();
        }

        public void UpdateScore()
        {
            score.text = ScoreManager.instance.Score.ToString();
        }

        public void UpdateLives(int lives)
        {
            for (int i = 0; i < this.lives.Length; i++)
            {
                if(i<lives)
                    this.lives[i].SetActive(true);
                else
                    this.lives[i].SetActive(false);
            }
        }

    }
}