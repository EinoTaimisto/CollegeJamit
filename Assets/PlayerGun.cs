using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button (0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate bullet at spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Set bullet tag
        bullet.tag = "Bullet";

        // Get the Rigidbody2D component of the bullet and set its velocity
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        if (bulletRB != null)
        {
            bulletRB.velocity = bulletSpawnPoint.up * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab does not have Rigidbody2D component attached.");
        }
    }

    // Ignore collisions between bullets and objects tagged as "Player"
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}