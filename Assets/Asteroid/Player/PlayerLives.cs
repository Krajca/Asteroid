using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AsteroidGame.UI;

namespace AsteroidGame.Player
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField]
        PlayerData playerData;
        int currentLives;

        void Start()
        {
            currentLives = playerData.PlayerLives;
            GameGUIScript.instance.UpdateLives(currentLives);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Die();
        }

        void Die()
        {
            --currentLives;
            GameGUIScript.instance.UpdateLives(currentLives);

            if (currentLives <= 0)
            {
                GameLoop.instance.EndGame();
            }
            else
            {
                GameLoop.instance.Restart();
            }
        }
    }
}