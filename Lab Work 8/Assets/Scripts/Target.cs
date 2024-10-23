using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Target : MonoBehaviour
{
    public string Shape { get; private set; }
    public float Speed { get; private set; }
    public float Size { get; private set; }
    public int PointValue { get; private set; }

    public void Initialize(string shape, float speed, float size, int pointValue)
    {
        Shape = shape;
        Speed = speed;
        Size = size;
        PointValue = pointValue;

        transform.localScale = new UnityEngine.Vector3(size, size, 1); // Adjust visual size
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) // Ensure your bullet has this tag
        {
            // Handle scoring here
            ScoreManager.Instance.OnTargetHit(PointValue);
            gameObject.SetActive(false); // Deactivate the target
        }
    }
}