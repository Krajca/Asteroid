using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AsteroidGame.Player;

namespace AsteroidGame.Input
{
    public class PCInput : MonoBehaviour
    {
        PlayerMovement pm;
        PlayerShooting ps;

        private void Awake()
        {
            pm = FindObjectOfType<PlayerMovement>();
            ps = FindObjectOfType<PlayerShooting>();
        }

        void Start()
        {

        }

        void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
            {
                pm.Accelerate();
            }
            if(UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                pm.Turn(false);
            }
            if(UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                pm.Turn(true);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                ps.Shoot();
            }
        }
    }
}