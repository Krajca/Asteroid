
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO Consider to add pooling for asteroids -- need more time for size/type differences
public class AsteroidSpawner : MonoBehaviour
{ 
    public AsteroidSpawnerData spawnerData;

    float maxCamBound;

    void Start()
    {
        maxCamBound = Camera.main.orthographicSize * Camera.main.aspect;
    }

    public void SpawnNewBig(int amount)
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

            asteroid.Initialize(rndPos, spawnerData.AsteroidSpeed, rndHeading.normalized, AsteroidSize.big, 1, this);

            obj.SetActive(true);
        }
    }

    public void SpawnSmallerAsteroid(Asteroid bigAsteroid)
    {
        //take medium sized asteroid with big asteroid type
        GameObject prefab = spawnerData.AsteroidTypes[bigAsteroid.Type]
            .mediumAsteroidPrefabs[Random.Range(0, spawnerData.AsteroidTypes[bigAsteroid.Type].mediumAsteroidPrefabs.Length)];

        //Instantiate and initialize
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);

        Asteroid asteroid = obj.GetComponent<Asteroid>();

        Vector2 rndPos = bigAsteroid.transform.position;
        Vector2 rndHeading = Random.insideUnitCircle.normalized;

        asteroid.Initialize(rndPos, spawnerData.AsteroidSpeed, rndHeading, bigAsteroid.Size-1, 1, this);

        obj.SetActive(true);
    }

}
