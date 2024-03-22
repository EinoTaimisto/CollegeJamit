using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    public GameObject gun; // Reference to the gun object
    public float rotationSpeed = 5f; // Speed of gun rotation
    public GameObject bulletPrefab; // Prefab of the bullet object
    public Transform firePoint; // Point where the bullet will be spawned
    public LayerMask enemyLayer; // Layer containing enemy objects

    void Update()
    {
        // Rotate the gun based on mouse position
        RotateGun();

        // Check for shooting input
        if (Input.GetButtonDown("Fire1")) // Assuming Fire1 is left mouse button
        {
            Shoot();
        }
    }

    void RotateGun()
    {
        // Get the direction from the gun's position to the mouse position
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(gun.transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the gun smoothly towards the mouse position
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        // Spawn a bullet at the fire point
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Check for collision with enemies
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, Mathf.Infinity, enemyLayer);

        if (hit.collider != null)
        {
            // Destroy the enemy if hit
            Destroy(hit.collider.gameObject);
        }
    }
}

