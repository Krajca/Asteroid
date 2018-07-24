using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public AsteroidSpawner asteroidSpawner;

    
    /// <summary>
    /// Time to wait at beginning of the game
    /// </summary>
    float beginWaitTime = 1f;


    void Start()
    {
        Invoke("StartGame", beginWaitTime);
    }


    void Update()
    {

    }

    public void StartGame()
    {

        asteroidSpawner.SpawnNewBig(3);
    }
}
