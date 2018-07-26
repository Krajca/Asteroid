using UnityEngine;

using AsteroidGame.UI;
using AsteroidGame.Sound;

namespace AsteroidGame.Player
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField]
        PlayerData playerData;

        [SerializeField]
        SpriteRenderer body;

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
            SoundPlayer.instance.PlayPlayerDeathSound();
            body.enabled = false;

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

        public void SpawnPlayer()
        {
            Invoke("Spawn", playerData.PlayerRespawnTime);
        }

        public void Spawn()
        {
            SoundPlayer.instance.PlayPlayerRespawnSound();
            GameLoop.instance.TurnInputOn();
            body.enabled = true;
        }
    }
}