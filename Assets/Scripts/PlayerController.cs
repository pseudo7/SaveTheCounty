using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform barrel;
    public float fireRate = 3;

    float countdown;

    void Update()
    {
        if (Input.GetMouseButton(0))
            FireAtRate();
    }

    void FireAtRate()
    {
        if (countdown > 1 / fireRate)
            Fire();
        else countdown += Time.deltaTime;
    }

    void Fire()
    {
        countdown = 0;
        var bullet = ObjectPooler.SharedInstance.GetPooledObject(0);
        bullet.transform.SetPositionAndRotation(barrel.position, barrel.rotation);
        bullet.SetActive(true);
    }
}
