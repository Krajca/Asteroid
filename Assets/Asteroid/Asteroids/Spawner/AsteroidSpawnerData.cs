using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidSpawnerData", menuName = "AsteroidData/AsteroidSpawnerData")]
public class AsteroidSpawnerData : ScriptableObject
{
    /// <summary>
    /// This will spawn asteroids further away.
    /// </summary>
    public float SpawnPositionOffsetBound;

    /// <summary>
    /// Size of accuracy circle at center of playground
    /// 0 - all asteroids will go thru center of map
    /// </summary>
    public float AccuracyOfAsteroids;

    public float AsteroidSpeed;

    public AsteroidTypeData[] AsteroidTypes;
}
