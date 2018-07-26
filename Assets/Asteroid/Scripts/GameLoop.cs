using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using AsteroidGame.UI;
using AsteroidGame.Asteroids;
using AsteroidGame.Player;

namespace AsteroidGame
{
    public class GameLoop : MonoBehaviour
    {
        public static GameLoop instance = null;

        [SerializeField]
        AsteroidSpawner asteroidSpawner;

        [SerializeField]
        AsteroidSpawnerData spawnerData;

        [SerializeField]
        PlayerMovement playerMovement;

        /// <summary>
        /// Time to wait at beginning of the game
        /// </summary>
        [SerializeField]
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
            Invoke("StartGame", spawnerData.TimeToNextRound);
        }

        public void StartGame()
        {
            asteroidSpawner.SpawnAsteroids();
        }

        public void EndGame()
        {
            //TODO GUI
            ScoreManager.instance.SaveIfNewHiScore();
            SceneManager.LoadScene("MenuScene");
        }

        public void Restart()
        {
            asteroidSpawner.ClearAsteroids();
            playerMovement.ResetToCenter();
            Invoke("StartGame", spawnerData.TimeToNextRound);
        }
    }
}