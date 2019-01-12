using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15;
    public float bulletLife = 1;

    Rigidbody2D bulletRB;

    private void OnEnable()
    {
        if (!bulletRB)
            bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        Invoke("DisableBullet", bulletLife);
    }

    void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
