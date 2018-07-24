
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject bigPrefab;
    public int pooledAmount;

    List<GameObject> bigAsteroids;
    List<GameObject> mediumAsteroids;
    List<GameObject> smallAsteroids;

    float positionBound = 2f;
    float headingBound = 5f;

    void Start()
    {
        bigAsteroids = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(bigPrefab);
            obj.SetActive(false);
            bigAsteroids.Add(obj);
        }


    }

    public void SpawnNewBig(int amount)
    {
        int a = 0;
        for (int i = 0; i < bigAsteroids.Count; i++)
        {
            if (!bigAsteroids[i].activeInHierarchy)
            {
                Asteroid asteroid = bigAsteroids[i].GetComponent<Asteroid>();

                Vector2 rndPos = Random.insideUnitCircle * ((Camera.main.orthographicSize * 2) + positionBound);
                Vector2 rndHeading = rndPos - (Random.insideUnitCircle * headingBound);

                asteroid.Initialize(rndPos, 3, rndHeading.normalized, AsteroidSize.big);

                bigAsteroids[i].SetActive(true);
                a++;
                if (a >= amount) return;
            }
        }
    }
}
