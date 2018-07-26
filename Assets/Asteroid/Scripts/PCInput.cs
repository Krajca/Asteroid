using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AsteroidGame.Player;

namespace AsteroidGame.Input
{
    //TODO add abstract Input class
    public class PCInput : MonoBehaviour
    {
        PlayerMovement pm;
        PlayerShooting ps;

        bool canPassInput;

        private void Awake()
        {
            pm = FindObjectOfType<PlayerMovement>();
            ps = FindObjectOfType<PlayerShooting>();

            canPassInput = true;
        }

        void Update()
        {
            if (canPassInput)
            {
                if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
                {
                    pm.Accelerate();
                }
                if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                {
                    pm.Turn(false);
                }
                if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                {
                    pm.Turn(true);
                }
                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                {
                    ps.Shoot();
                }
            }
        }

        public void SwitchInputTo(bool i)
        {
            canPassInput = i;
        }

    }
}