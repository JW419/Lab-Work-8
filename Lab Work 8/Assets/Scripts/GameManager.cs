using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject targetPrefab; // Assign your target prefab in the Inspector

    void Start()
    {
        TargetBuilder builder = new TargetBuilder();

        // Create the small fast target
        Target smallFastTarget = builder
            .SetShape("Circle")
            .SetSpeed(5.0f)
            .SetSize(1.0f)
            .SetPointValue(10)
            .Build();

        // Instantiate the target GameObject
        InstantiateTarget(smallFastTarget, new UnityEngine.Vector3(0, 0, 0));

        // Create the large slow target
        Target largeSlowTarget = builder
            .SetShape("Square")
            .SetSpeed(2.0f)
            .SetSize(1.0f)
            .SetPointValue(5)
            .Build();

        // Instantiate the target GameObject
        InstantiateTarget(largeSlowTarget, new UnityEngine.Vector3(2, 0, 0));
    }

    void InstantiateTarget(Target targetData, UnityEngine.Vector3 position)
    {
        // Get the camera's viewport position to calculate screen bounds
        Camera camera = Camera.main;
        UnityEngine.Vector3 screenBounds = camera.ScreenToWorldPoint(new UnityEngine.Vector3(Screen.width, Screen.height, camera.transform.position.z));

        // Generate a random position within the screen bounds
        float randomX = UnityEngine.Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = UnityEngine.Random.Range(-screenBounds.y, screenBounds.y);

        // Create a position vector
        UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(randomX, randomY, 0);

        // Instantiate the target GameObject
        GameObject targetObject = Instantiate(targetPrefab, spawnPosition, UnityEngine.Quaternion.identity);
        Target targetComponent = targetObject.GetComponent<Target>();
        targetComponent.Initialize(targetData.Shape, targetData.Speed, targetData.Size, targetData.PointValue);

        // Check if targetObject and its Renderer are active and visible
        if (targetObject != null)
        {
            UnityEngine.Debug.Log($"Instantiated target: {targetData.Shape} at position: {position}");

            // Set the scale of the target based on the size property
            targetObject.transform.localScale = new UnityEngine.Vector3(targetData.Size, targetData.Size, 1);

            // Ensure target is active
            targetObject.SetActive(true);

            // Check the renderer component
            SpriteRenderer renderer = targetObject.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                UnityEngine.Debug.Log($"Target Renderer: {renderer.name}, Is Visible: {renderer.isVisible}");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to instantiate targetObject");
        }
    }
}
