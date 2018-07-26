using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using AsteroidGame.UI;
using AsteroidGame.Input;
using AsteroidGame.Asteroids;
using AsteroidGame.Player;
using AsteroidGame.Sound;

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
        GameObject playerGameObject;

        [SerializeField]
        Input.Input input;


        PlayerMovement playerMovement;
        PlayerLives playerLives;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            playerMovement = playerGameObject.GetComponentInChildren<PlayerMovement>();
            playerLives = playerGameObject.GetComponentInChildren<PlayerLives>();
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
            input.SwitchInputTo(false);
            asteroidSpawner.ClearAsteroids();
            playerMovement.ResetToCenter();
            playerLives.SpawnPlayer();
            Invoke("StartGame", spawnerData.TimeToNextRound);
        }

        public void TurnInputOn()
        {
            input.SwitchInputTo(true);
        }
    }
}