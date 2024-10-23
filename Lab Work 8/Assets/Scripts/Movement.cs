using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from the horizontal axis (A/D or Left/Right)

        // Move the player left and right
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(moveHorizontal, 0, 0);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
