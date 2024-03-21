using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 1f; // Added semicolon at the end

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision) // Corrected the method name
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
