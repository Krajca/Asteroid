
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO Consider to add pooling for asteroids -- need more time for size/type differences
public class AsteroidSpawner : MonoBehaviour
{ 
    float positionBound = 2f;
    float headingBound = 2f;

    float maxCamBound;

    public AsteroidSpawnerData spawnerData;

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

            Vector2 rndPos = Random.insideUnitCircle.normalized * (maxCamBound + positionBound);
            Vector2 rndHeading = (Random.insideUnitCircle * headingBound) - rndPos;

            asteroid.Initialize(rndPos, 2, rndHeading.normalized, AsteroidSize.big, 1, this);

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

        asteroid.Initialize(rndPos, 2, rndHeading, bigAsteroid.Size+1, 1, this);

        obj.SetActive(true);
    }

}
