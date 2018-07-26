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

        public AudioClip MenuMusic;
        public AudioClip[] GameplayMusic;

        [Range(0, 1)]
        public float SoundsVolume = 0.1f;
        [Range(0, 1)]
        public float MusicVolume = 0.05f;

    }
}