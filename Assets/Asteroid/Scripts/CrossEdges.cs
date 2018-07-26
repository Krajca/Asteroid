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

        bool inPlay;

        private void Start()
        {
            horisontalBound = Camera.main.aspect * Camera.main.orthographicSize;
            verticalBound = Camera.main.orthographicSize;

            inPlay = false;
            StartCoroutine("CheckIfInPlay");
        }

        private void Update()
        {
            if (inPlay)
            {
                if (transform.position.y > verticalBound || transform.position.y < -verticalBound)
                {
                    transform.position = transform.position * new Vector2(1f, -0.99f);
                }
                if (transform.position.x > horisontalBound || transform.position.x < -horisontalBound)
                {
                    transform.position = transform.position * new Vector2(-0.99f, 1f);
                }
            }
        }

        IEnumerator CheckIfInPlay()
        {
            yield return new WaitUntil(() => 
                { return transform.position.y < verticalBound && 
                         transform.position.y > -verticalBound && 
                         transform.position.x < horisontalBound && 
                         transform.position.x > -horisontalBound;
                });
            inPlay = true;
        }
    }
}