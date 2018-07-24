using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public AsteroidSize size
    {
        get;
        protected set;
    }
  
    float speed = 1;
    Vector2 heading = Vector2.up;

    void FixedUpdate()
    {
        transform.Translate(heading * speed * Time.fixedDeltaTime);
        //TODO / IDEA add rotation for better visual effect 
    }

    public void Initialize(Vector3 position, int speed, Vector2 heading, AsteroidSize size)
    {
        this.transform.position = position;
        this.speed = speed;
        this.heading = heading;
        this.size = size;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnBecameInvisible()
    {
        transform.position = (Vector2)transform.position * - 1;
    }
    
}

public enum AsteroidSize
{
    small,
    medium,
    big
}
