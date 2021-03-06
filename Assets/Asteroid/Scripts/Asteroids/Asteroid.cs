﻿using UnityEngine;

namespace AsteroidGame.Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        public AsteroidSize Size
        {
            get;
            protected set;
        }
        public int Type
        {
            get;
            protected set;
        }
        public Vector2 Heading
        {
            get;
            protected set;
        }

        float speed;
        AsteroidSpawner asteroidSpawner;

        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            rb.velocity = Heading * speed;
            rb.angularVelocity = speed * (Random.value-0.5f) * 20;
        }

        public void Initialize(Vector3 position, float speed, Vector2 heading, AsteroidSize size, int type, AsteroidSpawner asteroidSpawner)
        {
            transform.position = position;
            Heading = heading;
            Size = size;
            Type = type;
            this.speed = speed;
            this.asteroidSpawner = asteroidSpawner;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Bullets"))
            {
                GetComponent<Collider2D>().enabled = false;
                asteroidSpawner.SpawnSmallerAsteroid(this);
                Destroy(this.gameObject);
            }
        }
    }
}