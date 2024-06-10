using UnityEngine;
using UnityEngine.UI;

public class TriggerBoxCollider : MonoBehaviour
{
    [Tooltip("Drag the XR RigidBody here")]
    public Rigidbody XRrigidbody; // The XR RigidBody we are checking for

    [Tooltip("Drag the Box Collider here")]
    public BoxCollider boxCollider; // The Box Collider trigger

    [Tooltip("Drag the UI Dialog Box here")]
    public GameObject dialogBox; // The UI Dialog Box to show

    void Start()
    {
        // Ensure the dialog box is hidden at start
        dialogBox.SetActive(false);
    }

    void Update()
    {
        // If the XR RigidBody is within the Box Collider
        if (boxCollider.bounds.Contains(XRrigidbody.position))
        {
            // Show the dialog box
            dialogBox.SetActive(true);
        }
        else
        {
            // Hide the dialog box
            dialogBox.SetActive(false);
        }
    }
}