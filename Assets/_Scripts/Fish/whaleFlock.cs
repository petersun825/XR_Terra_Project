

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whaleFlock : MonoBehaviour
{
    public float speed = -0.5f;  // Forward speed
    public float rotationSpeed = 1.0f;  // Rotation speed for random turns
    public BoxCollider water;
    public TerrainCollider terrain;
    private Rigidbody rb;  // Rigidbody component

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the whale forward
        rb.velocity = transform.forward * speed;

        // Randomly rotate the whale
        if (Random.Range(0, 100) < 1)  // 1% chance to initiate a turn
        {
            // Apply torque for rotation
            rb.AddTorque(Vector3.up * Random.Range(-rotationSpeed, rotationSpeed));
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the object exited the WaterPlane's trigger
        if (other == water)
        {
            // Deactivate the script
            this.enabled = false;

            // Activate gravity
            rb.useGravity = true;
        }
    }

    void OnCollision(TerrainCollider terrain)
    {
        //transform.rotation *= Quaternion.Euler(0, 90, 0);
        rb.AddTorque(Vector3.up * 30);
    }//Random.Range(-rotationSpeed, rotationSpeed);

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entered the WaterPlane's trigger
        if (other == water)
        {
            // Start the coroutine to enable the script after 1 second
            StartCoroutine(EnableScriptAfterDelay(7.0f));
        }
    }

    IEnumerator EnableScriptAfterDelay(float delay)
    {
        // Deactivate gravity
        rb.useGravity = false;

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Reactivate the script
        this.enabled = true;
    }
}
