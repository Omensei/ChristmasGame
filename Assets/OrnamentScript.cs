using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnamentScript : MonoBehaviour
{
    public GameObject ornam; // The object to spawn
    public PlayerMovement player; // Reference to the player's script
    public Rigidbody2D rb; // Rigidbody2D component
    public float gravity = 5f; // Gravity scale to set
    public float spawnDistance = 5f; // Distance to start spawning items
    public float maxDistance = 20f; // Maximum distance before objects are destroyed
    private bool isCoroutineRunning = false; // Flag to prevent multiple coroutines
    private GameObject currentOrnament = null; // Track the currently spawned object

    private Vector3 initial_position; // Store initial position if needed

    void Start()
    {
        initial_position = transform.position; // Save initial position
    }

    void Update()
    {
        // Apply gravity if the player is nearby
        if (Vector3.Distance(transform.position, player.transform.position) < spawnDistance)
        {
            rb.gravityScale = gravity;
        }

        // Check if the player is far enough and no ornament is active
        if (Vector3.Distance(transform.position, player.transform.position) > spawnDistance * 5 && currentOrnament == null)
        {
            if (!isCoroutineRunning)
            {
                StartCoroutine(spawnCoroutine());
            }
        }

        // Check and destroy the current ornament if it gets too far
        if (currentOrnament != null && Vector3.Distance(initial_position, currentOrnament.transform.position) > maxDistance)
        {
            Destroy(currentOrnament);
            currentOrnament = null; // Reset to allow spawning a new ornament
        }
    }

    IEnumerator spawnCoroutine()
    {
        isCoroutineRunning = true; // Set flag to prevent multiple instances
        yield return new WaitForSeconds(2); // Wait for 2 seconds

        // Instantiate the new object
        currentOrnament = Instantiate(ornam, initial_position, Quaternion.identity);

        isCoroutineRunning = false; // Reset flag to allow new coroutine to start if necessary
    }
}
