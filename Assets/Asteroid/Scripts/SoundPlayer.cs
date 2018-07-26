using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        public static SoundPlayer instance = null;

        [SerializeField]
        SoundData soundData;

        AudioSource ShotsAudioSource;
        AudioSource OtherAudioSource;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            ShotsAudioSource = gameObject.AddComponent<AudioSource>();
            OtherAudioSource = gameObject.AddComponent<AudioSource>();

            DontDestroyOnLoad(gameObject);
        }

        public void PlayShotSound()
        {
            ShotsAudioSource.clip = soundData.Shot;

            if(soundData.RandomizeShotSound)
                ShotsAudioSource.pitch = Random.Range(soundData.LowPitchRange, soundData.HighPitchRange);

            ShotsAudioSource.Play();
        }
        public void PlayPlayerDeathSound()
        {
            OtherAudioSource.clip = soundData.PlayerDeath;
            OtherAudioSource.Play();
        }
        public void PlayPlayerRespawnSound()
        {
            OtherAudioSource.clip = soundData.PlayerRespawn;
            OtherAudioSource.Play();
        }

        public void PlayExplosionSound()
        {
            OtherAudioSource.clip = soundData.Explosion;
            OtherAudioSource.Play();
        }
    }
}