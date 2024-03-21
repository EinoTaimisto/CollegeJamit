using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxHp = 100;
    private Transform target; // Reference to the target (player) Transform
    private NavMeshAgent agent;

    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Find the player GameObject with the "Player" tag at runtime
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            // If player object is found, assign its transform to the target
            target = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found! Make sure the player GameObject has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            Debug.LogError("Target (player) is null!");
        }
    }
}
