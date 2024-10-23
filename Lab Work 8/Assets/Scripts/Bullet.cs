using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public TargetNotifier targetHitNotifier; // Reference to notify when a target is hit
    public int points = 10; // Points to give when hitting a target

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target")) // Ensure your target has the tag "Target"
        {
            targetHitNotifier.Notify(points); // Notify the target hit
            gameObject.SetActive(false); // Disable the bullet after hit
        }
    }
    private void OnEnable()
    {
        // Start the bullet's movement
        Invoke("Disable", lifetime); // Disable after a certain time
    }

    private void Update()
    {
        // Move the bullet up the Y-axis (or adjust for your game's needs)
        transform.Translate(UnityEngine.Vector2.up * speed * Time.deltaTime);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke(); // Cancel the invocation if bullet is reused
    }
}
