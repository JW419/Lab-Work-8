using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuilder : MonoBehaviour
{
    private string shape;
    private float speed;
    private float size;
    private int pointValue;

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

    // No need for a constructor here
    public Target Build()
    {
        // You just return null or a new instance of Target, since the actual
        // target will be instantiated in the GameManager.
        return new Target(); // You can keep this if you want an empty Target instance for any reason.
    }
}
