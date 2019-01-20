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
    public GameObject missilePrefab;
    bool dead;
    bool flyingToLeft;
    float flyingSpeed;
    private float countdown;

    private void Start()
    {
        flyingSpeed = Random.Range(flyingSpeedBounds[0], flyingSpeedBounds[1]);
        fireRate = GameManager.Instance.currentFireRate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.BULLET_TAG))
        {
            if (dead)
                return;
            collision.gameObject.SetActive(false);
            BulletHit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Constants.GROUND_TAG))
        {
            GameManager.Instance.SpawnBlast(new Vector3(collision.otherCollider.transform.position.x, -4.5f));
            GameManager.Instance.UpdateScore();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (dead)
            return;
        Fly();
        Rotate();
        FireAtRate();
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

    void FireAtRate()
    {
        if (countdown > 1 / fireRate) Shoot();
        else countdown += Time.deltaTime;
    }

    void Shoot()
    {
        countdown = 0;
        Instantiate(missilePrefab, transform.position, missilePrefab.transform.rotation);
    }

    void BulletHit()
    {
        if (--health <= 0)
        {
            dead = true;
            var shipRB = GetComponent<Rigidbody2D>();
            shipRB.gravityScale = .8f;
            shipRB.AddForce(flyingToLeft ? -transform.right : transform.right, ForceMode2D.Impulse);
            shipRB.AddTorque(.5f, ForceMode2D.Impulse);
        }
    }
}