using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AsteroidGame.Sound;

namespace AsteroidGame.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField]
        BulletSpawnerData bulletSpawnerData;

        [SerializeField]
        Transform bulletSpawn;

        List<GameObject> bullets;

        void Start()
        {
            bullets = new List<GameObject>();
            for (int i = 0; i < bulletSpawnerData.bulletPoolSize; i++)
            {
                GameObject go = Instantiate(bulletSpawnerData.BulletPrefab);
                go.SetActive(false);
                bullets.Add(go);
            }
        }

        public void Shoot()
        {
            SoundPlayer.instance.PlayShotSound();

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    BulletScript bullet = bullets[i].GetComponent<BulletScript>();

                    Debug.Assert(bulletSpawn != null);
                    bullet.Initialize(
                        bulletSpawn.position, 
                        transform.rotation, 
                        bulletSpawnerData.bulletSpeed, 
                        bulletSpawnerData.bulletLifeTime);

                    bullets[i].SetActive(true);
                    return;
                }
            }
        }
    }
}
