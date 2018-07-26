using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletScript : MonoBehaviour
    {
        Vector2 heading;
        float speed;
        float lifeTime;
        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            Vector2 dir = transform.rotation * Vector2.up;
            rb.velocity = dir * speed;

            Invoke("Deactivate", lifeTime);
        }

        public void Initialize(Vector3 position, Quaternion rotation, float speed, float lifeTime)
        {
            transform.position = position;
            transform.rotation = rotation;
            this.speed = speed;
            this.lifeTime = lifeTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Deactivate();
        }

        void Deactivate()
        {
            gameObject.SetActive(false);
            CancelInvoke();
        }
    }
}