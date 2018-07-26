using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using AsteroidGame.UI;
using AsteroidGame.Input;
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

        [SerializeField]
        PCInput input;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            input = GetComponent<PCInput>();
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
            asteroidSpawner.ClearAsteroids();
            input.SwitchInputTo(false);
            playerMovement.gameObject.SetActive(false);
            GameGUIScript.instance.EndGameGUI();
        }

        public void Restart()
        {
            asteroidSpawner.ClearAsteroids();
            playerMovement.ResetToCenter();
            Invoke("StartGame", spawnerData.TimeToNextRound);
        }
    }
}