using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AsteroidGame.Player
{
    [CreateAssetMenu(fileName = "BulletSpawnerData", menuName = "AsteroidData/BulletSpawnerDatas")]
    public class BulletSpawnerData : ScriptableObject
    {
        public GameObject BulletPrefab;
        public int bulletPoolSize = 20;

        public float bulletSpeed = 1f;
        public float bulletLifeTime = 2f;
    }
}