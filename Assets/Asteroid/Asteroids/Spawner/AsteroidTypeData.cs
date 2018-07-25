using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidTypeData", menuName = "AsteroidData/AsteroidTypeData")]
public class AsteroidTypeData : ScriptableObject
{
    public GameObject[] bigAsteroidPrefabs;
    public GameObject[] mediumAsteroidPrefabs;
    public GameObject[] smallAsteroidPrefabs;
}
