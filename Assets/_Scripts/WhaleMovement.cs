using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    public float speed = -2.0f; // Speed of the whale
    public float turnSpeed = 5.0f; // Turning speed of the whale
    private float turnDirection = 0.0f; // Current direction of turn, 0 means straight
    public Rigidbody rb; // Rigidbody component
    public Collider boundingBox; // Collider for the bounding box

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
   
    }

    void Update()
    {
        // Randomly change the turn direction occasionally
        if (Random.Range(0, 100) < 2) // 2% chance to change direction each frame
        {
            turnDirection = Random.Range(-1, 2); // -1 = left, 0 = straight, 1 = right
        }

        // Calculate potential new position and rotation
        Quaternion turn = Quaternion.Euler(0, turnDirection * turnSpeed * Time.deltaTime, 0);
        Vector3 newPosition = rb.position + transform.forward * speed * Time.deltaTime;
        Quaternion newRotation = rb.rotation * turn;

        // Check if the new position is within the bounding box
        if (boundingBox.bounds.Contains(newPosition))
        {
            // Apply the rotation and move the whale forward if within bounds
            rb.MoveRotation(newRotation);
            rb.MovePosition(newPosition);
        }
        else
        {
            // Change direction if heading out of bounds
            turnDirection = -turnDirection;
        }
    }
}
