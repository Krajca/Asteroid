using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Sound
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "AsteroidData/SoundData")]
    public class SoundData : ScriptableObject
    {
        public AudioClip Shot;
        public AudioClip Explosion;
        public AudioClip PlayerDeath;
        public AudioClip PlayerRespawn;

        public bool RandomizeShotSound;
        [Tooltip("Used for randomize shoot sound")]
        public float LowPitchRange;
        [Tooltip("Used for randomize shoot sound")]
        public float HighPitchRange;
    }
}