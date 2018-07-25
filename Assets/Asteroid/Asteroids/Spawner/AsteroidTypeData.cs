using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidTypeData", menuName = "AsteroidData/AsteroidTypeData")]
    public class AsteroidTypeData : ScriptableObject
    {
        public GameObject[] bigAsteroidPrefabs;
        public GameObject[] mediumAsteroidPrefabs;
        public GameObject[] smallAsteroidPrefabs;
    }
}