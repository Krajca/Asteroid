using System.Collections.Generic;
using UnityEngine;

using AsteroidGame.UI;

namespace AsteroidGame.Asteroids
{
    //TODO Consider to add pooling for asteroids -- need more time for size/type differences
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        AsteroidSpawnerData spawnerData;

        float maxCamBound;

        List<Asteroid> asteroids;

        void Start()
        {
            maxCamBound = Camera.main.orthographicSize * Camera.main.aspect;
            asteroids = new List<Asteroid>();
        }

        public void SpawnAsteroids()
        {
            SpawnBigAsteroid(spawnerData.NewRoundAsteroidCount);
        }

        void SpawnBigAsteroid(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                //take big asteroid of random type
                int type = Random.Range(0, spawnerData.AsteroidTypes.Length);
                GameObject prefab = spawnerData.AsteroidTypes[type]
                    .bigAsteroidPrefabs[Random.Range(0, spawnerData.AsteroidTypes[type].bigAsteroidPrefabs.Length)];

                //Instantiate and initialize
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);

                Asteroid asteroid = obj.GetComponent<Asteroid>();

                Vector2 rndPos = Random.insideUnitCircle.normalized * (maxCamBound + spawnerData.SpawnPositionOffsetBound);
                Vector2 rndHeading = (Random.insideUnitCircle * spawnerData.AccuracyOfAsteroids) - rndPos;

                asteroid.Initialize(rndPos, spawnerData.AsteroidSpeed, rndHeading.normalized, AsteroidSize.big, type, this);
                asteroids.Add(asteroid);

                obj.SetActive(true);
            }
        }

        public void SpawnSmallerAsteroid(Asteroid bigAsteroid)
        {
            asteroids.Remove(bigAsteroid);
            if (bigAsteroid.Size != AsteroidSize.small)
            {
                InstantiateSmallerAsteroid(bigAsteroid);
                InstantiateSmallerAsteroid(bigAsteroid);
            }

            ScoreManager.instance.AddScore(spawnerData.PointsForAsteroids[(int)bigAsteroid.Size]);
            GameGUIScript.instance.UpdateScore();


            if (asteroids.Count <= 0)
            {
                Invoke("SpawnAsteroids", spawnerData.TimeToNextRound);
            }
        }

        void InstantiateSmallerAsteroid(Asteroid bigAsteroid)
        {
            //take smaller sized asteroid with bigger asteroid type
            GameObject prefab;
            if (bigAsteroid.Size == AsteroidSize.big)
            {
                prefab = spawnerData.AsteroidTypes[bigAsteroid.Type]
                    .mediumAsteroidPrefabs[Random.Range(0, spawnerData.AsteroidTypes[bigAsteroid.Type].mediumAsteroidPrefabs.Length)];
            }
            else
            {
                prefab = spawnerData.AsteroidTypes[bigAsteroid.Type]
                    .smallAsteroidPrefabs[Random.Range(0, spawnerData.AsteroidTypes[bigAsteroid.Type].smallAsteroidPrefabs.Length)];
            }

            //Instantiate and initialize
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);

            Asteroid asteroid = obj.GetComponent<Asteroid>();

            Vector2 rndPos = bigAsteroid.transform.position;
            Vector2 rndHeading = Random.insideUnitCircle.normalized;

            asteroid.Initialize(rndPos, spawnerData.AsteroidSpeed, rndHeading, bigAsteroid.Size - 1, bigAsteroid.Type, this);
            asteroids.Add(asteroid);

            obj.SetActive(true);
        }

        public void ClearAsteroids()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                Destroy(asteroids[i].gameObject);
            }
            asteroids.Clear();
        }
    }
}