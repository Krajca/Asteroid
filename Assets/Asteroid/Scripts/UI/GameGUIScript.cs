using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        [SerializeField]
        GameObject endGamePanel;
        [SerializeField]
        Text endScore;
        [SerializeField]
        Text endHiScore;
        [SerializeField]
        GameObject announcement;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
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

        public void EndGameGUI()
        {
            endScore.text = ScoreManager.instance.Score.ToString();
            endHiScore.text = ScoreManager.instance.HiScore.ToString();
            bool isNewHS = ScoreManager.instance.SaveIfNewHiScore();
            if (isNewHS) announcement.SetActive(true);
            endGamePanel.SetActive(true);
        }

        public void ButtonEndGame()
        {
            endGamePanel.SetActive(false);
            SceneManager.LoadScene("MenuScene");
        }

        public void ButtonRestart()
        {
            endGamePanel.SetActive(false);
            SceneManager.LoadScene("GameScene");
        }
    }
}