using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ObjectPool bulletPool;
    public TargetNotifier targetHitNotifier; // Reference to the notifier
    public int pointsPerHit = 10; // Points awarded for each hit

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire when the button is pressed
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = bulletPool.GetBullet(); // Get a bullet from the pool
        bullet.transform.position = transform.position; // Set the bullet's position
        bullet.transform.rotation = UnityEngine.Quaternion.identity; // Reset rotation if needed

        Bullet bulletScript = bullet.GetComponent<Bullet>(); // Get the Bullet component
        bulletScript.targetHitNotifier = targetHitNotifier;
        // Simulate a hit for demonstration purposes (you'll replace this with actual hit detection)
        HitTarget();
    }

    private void HitTarget()
    {
        // Notify observers that a target was hit
        targetHitNotifier.Notify(pointsPerHit);
    }
}
