using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int health = 10;
    public float fireRate = 2;
    public Vector3 rotationAngle = Vector3.up;
    public float rotationSpeed = 100;

    bool dead;

    private void Update()
    {
        if (!dead)
            transform.Rotate(rotationAngle * Time.deltaTime * rotationSpeed);
    }

    void BulletHit()
    {
        if (--health <= 0)
            dead = true;
    }
}
