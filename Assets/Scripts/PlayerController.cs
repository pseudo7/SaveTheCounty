using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform barrel;
    public float fireRate = 3;
    public int health = 100;
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
        AudioManager.Instance.Play(Constants.SHOT_AUDIO);
        countdown = 0;
        var bullet = ObjectPooler.SharedInstance.GetPooledObject(0);
        bullet.transform.SetPositionAndRotation(barrel.position, barrel.rotation);
        bullet.SetActive(true);
    }
}
