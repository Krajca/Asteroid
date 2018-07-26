using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame
{
    public class CrossEdges : MonoBehaviour
    {
        Rigidbody2D rb;

        float horisontalBound;
        float verticalBound;

        private void Start()
        {
            horisontalBound = Camera.main.aspect * Camera.main.orthographicSize;
            verticalBound = Camera.main.orthographicSize;
        }

        private void Update()
        {
            if(transform.position.y > verticalBound || transform.position.y < -verticalBound)
            {
                transform.position = transform.position * new Vector2(1f,-0.9f);
            }
            if (transform.position.x > horisontalBound || transform.position.x < -horisontalBound)
            {
                transform.position = transform.position * new Vector2(-0.9f, 1f);
            }
        }
    }
}