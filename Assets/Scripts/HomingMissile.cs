using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 200f;

    Transform playerTransform;
    Rigidbody2D rB;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).transform;
        rB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.PLAYER_TAG))
        {
            GameManager.Instance.SpawnBlast(transform.position + Vector3.down, 0);
            GameManager.Instance.UpdateHealth();
        }
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rB.velocity = transform.up * speed;
        var direction = rB.position - (Vector2)playerTransform.position;

        float rotZ = Vector3.Cross(direction, transform.up).z;
        rB.angularVelocity = rotZ * rotationSpeed;
    }
}
