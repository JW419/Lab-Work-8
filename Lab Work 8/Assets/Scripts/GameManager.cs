using System.Collections;
using System.Collections.Generic;
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
            .SetSize(0.5f)
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
        GameObject targetObject = Instantiate(targetPrefab, position, UnityEngine.Quaternion.identity);
        Target targetComponent = targetObject.GetComponent<Target>();
        targetComponent.Initialize(targetData.Shape, targetData.Speed, targetData.Size, targetData.PointValue);
        targetObject.SetActive(true);
    }
}
