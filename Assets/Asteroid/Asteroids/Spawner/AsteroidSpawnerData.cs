using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidSpawnerData", menuName = "AsteroidData/AsteroidSpawnerData")]
    public class AsteroidSpawnerData : ScriptableObject
    {
        /// <summary>
        /// This will spawn asteroids further away.
        /// </summary>
        [Tooltip("This will spawn asteroids further away.")]
        public float SpawnPositionOffsetBound;

        /// <summary>
        /// Size of accuracy circle at center of playground
        /// 0 - all asteroids will go thru center of map
        /// </summary>
        [Tooltip("Size of accuracy circle at center of playground. 0 - all asteroids will go thru center of map.")]
        public float AccuracyOfAsteroids;

        public float AsteroidSpeed;

        public float TimeToNextRound;
        public int NewRoundAsteroidCount;

        /// <summary>
        /// Points for destroying an asteroid
        /// Please check AsteroidSize.cs for details
        /// </summary>
        [Tooltip("Points for destroying an asteroid. Please check AsteroidSize.cs for details")]
        public int[] PointsForAsteroids;

        public AsteroidTypeData[] AsteroidTypes;
    }
}