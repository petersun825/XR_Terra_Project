using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            Debug.Log("Collided with the Sphere");
        }
        Debug.Log("Detected Collided with: " + collision.impulse + "Gameobject: "+collision.gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
