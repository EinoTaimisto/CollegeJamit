using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameObject door;
    public int EnemyCount = 100; // Initial enemy count
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(collision.gameObject);
            Destroy(collision.collider.gameObject);
            EnemyCount--;
            Debug.Log(EnemyCount);
            if (EnemyCount == 0)
            {
                door.SetActive(false);
            }
        }
    }
}
