using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int health = 10;
    public float fireRate = 2;
    public Vector3 rotationAngle = Vector3.up;
    public float rotationSpeed = 100;
    public float flyingRange = 7.5f;
    public Vector2 flyingSpeedBounds = new Vector2(1, 5);

    bool dead;
    bool flyingToLeft;
    float flyingSpeed;

    private void Start()
    {
        flyingSpeed = Random.Range(flyingSpeedBounds[0], flyingSpeedBounds[1]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.BULLET_TAG))
        {
            Debug.Log("HIT");
            BulletHit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Constants.GROUND_TAG))
        {
            GameManager.Instance.SpawnBlast(collision.otherCollider.transform.position + Vector3.back * 5);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (dead)
            return;
        Fly();
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(rotationAngle * Time.deltaTime * rotationSpeed);
    }

    void Fly()
    {
        if (transform.position.x < -flyingRange || transform.position.x > flyingRange)
            flyingToLeft = !flyingToLeft;
        transform.position += (flyingToLeft ? Vector3.left : Vector3.right) * Time.deltaTime * flyingSpeed;
    }

    void BulletHit()
    {
        if (--health <= 0)
        {
            dead = true;
            var shipRB = GetComponent<Rigidbody2D>();
            shipRB.gravityScale = 1;
            shipRB.AddForce(flyingToLeft ? -transform.right : transform.right, ForceMode2D.Impulse);
        }
    }
}