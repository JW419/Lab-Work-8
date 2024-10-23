using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab
    public int poolSize = 10; // Number of bullets to pool

    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    private void Start()
    {
        // Pre-instantiate bullets and add them to the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false); // Deactivate the bullet initially
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue(); // Get a bullet from the pool
            bullet.SetActive(true); // Activate the bullet
            return bullet;
        }
        else
        {
            // Optionally: Instantiate a new bullet if pool is empty
            GameObject bullet = Instantiate(bulletPrefab);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false); // Deactivate the bullet
        bulletPool.Enqueue(bullet); // Return it to the pool
    }
}
