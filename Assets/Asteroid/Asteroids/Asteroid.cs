using UnityEngine;

namespace AsteroidGame.Asteroids
{
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

        private void OnCollisionEnter2D()
        {
            if (Size != AsteroidSize.small)
            {
                asteroidSpawner.SpawnSmallerAsteroid(this);
                asteroidSpawner.SpawnSmallerAsteroid(this);
            }
            Destroy(this.gameObject);
        }


        void OnBecameInvisible()
        {
            //TODO fix: this behaviour is different from original game  
            transform.position = transform.position * -1;

            //this should work but seems to be buggy
            /*if (Mathf.Abs(transform.position.x) >= cameraVerticalSize)
            {
                transform.position = Vector3.Scale(transform.position, new Vector3(-1, 1, 1));
            }
            else
            {
                transform.position = Vector3.Scale(transform.position, new Vector3(1, -1, 1));
            } */
        }
    }
}