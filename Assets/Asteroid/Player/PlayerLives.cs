using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Player
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField]
        PlayerData playerData;
        int currentLives;

        string currentLivesID = "currentLives";

        void Start()
        {
            currentLives = PlayerPrefs.GetInt(currentLivesID, playerData.PlayerLives);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Die();
        }

        void Die()
        {

            if (--currentLives <= 0)
            {
                PlayerPrefs.DeleteKey(currentLivesID);
                GameLoop.instance.EndGame();
            }
            else
            {
                PlayerPrefs.SetInt(currentLivesID, currentLives);
                GameLoop.instance.Restart();
            }
        }
    }
}