using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited by: "+other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("On Frame: " + other.name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
