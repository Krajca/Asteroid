using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AsteroidGame.Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        public static SoundPlayer instance = null;

        [SerializeField]
        SoundData soundData;

        AudioSource ShotsAudioSource;
        AudioSource OtherAudioSource;

        AudioSource MusicAudioSource;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            ShotsAudioSource = gameObject.AddComponent<AudioSource>();
            OtherAudioSource = gameObject.AddComponent<AudioSource>();
            MusicAudioSource = gameObject.AddComponent<AudioSource>();

            ShotsAudioSource.volume = 0.1f;
            MusicAudioSource.volume = 0.01f;

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
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

        public void PlayMenuMusic()
        {
            MusicAudioSource.clip = soundData.MenuMusic;
            MusicAudioSource.Play();
        }
        public void PlayRandomGameplayMusic()
        {
            MusicAudioSource.clip = soundData.GameplayMusic[Random.Range(0, soundData.GameplayMusic.Length)];
            MusicAudioSource.Play();
        }


        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            switch (scene.name)
            {
                case "MenuScene":
                    PlayMenuMusic();
                    break;
                case "GameScene":
                    PlayRandomGameplayMusic();
                    break;
                default:
                    break;
            }
        }

    }
}