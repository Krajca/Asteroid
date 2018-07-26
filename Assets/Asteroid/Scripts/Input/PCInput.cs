using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AsteroidGame.Player;

namespace AsteroidGame.Input
{
    public class PCInput : Input
    {
        PlayerMovement playerMovement;
        PlayerShooting playerShooting;

        private void Awake()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            playerShooting = FindObjectOfType<PlayerShooting>();

            canPassInput = true;
        }

        void Update()
        {
            if (canPassInput)
            {
                if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
                {
                    playerMovement.Accelerate();
                }
                if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                {
                    playerMovement.Turn(false);
                }
                if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                {
                    playerMovement.Turn(true);
                }
                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                {
                    playerShooting.Shoot();
                }
            }
        }
    }
}