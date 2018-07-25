using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AsteroidGame.Asteroids;
using UnityEngine.SceneManagement;

namespace AsteroidGame
{
    public class GameLoop : MonoBehaviour
    {
        public static GameLoop instance = null;

        [SerializeField]
        AsteroidSpawner asteroidSpawner;


        /// <summary>
        /// Time to wait at beginning of the game
        /// </summary>
        float beginWaitTime = 2f;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }


        void Start()
        {
            ScoreManager.instance.ClearScore();
            Invoke("StartGame", beginWaitTime);
        }

        public void StartGame()
        {
            asteroidSpawner.SpawnBigAsteroid(3);
        }

        public void EndGame()
        {
            ScoreManager.instance.SaveIfNewHiScore();
            SceneManager.LoadScene("MenuScene");
        }

        public void Restart()
        {
            ScoreManager.instance.SaveCurrentScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}