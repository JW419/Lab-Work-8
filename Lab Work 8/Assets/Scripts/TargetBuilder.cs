using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuilder
{
    private string shape;
    private float speed;
    private float size;
    private int pointValue;
    public GameObject targetPrefab; // Add reference to your target prefab

    public TargetBuilder SetShape(string shape)
    {
        this.shape = shape;
        return this;
    }

    public TargetBuilder SetSpeed(float speed)
    {
        this.speed = speed;
        return this;
    }

    public TargetBuilder SetSize(float size)
    {
        this.size = size;
        return this;
    }

    public TargetBuilder SetPointValue(int pointValue)
    {
        this.pointValue = pointValue;
        return this;
    }

    public GameObject Build()
    {
        GameObject targetObject = Instantiate(targetPrefab); // Instantiate target prefab
        Target targetComponent = targetObject.GetComponent<Target>();

        // Initialize target component with the set values
        targetComponent.Initialize(shape, speed, size, pointValue);

        return targetObject; // Return the instantiated GameObject
    }
}
