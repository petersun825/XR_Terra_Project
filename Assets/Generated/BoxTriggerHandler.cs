using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerHandler : MonoBehaviour
{
    [Tooltip("Reference to the Canvas GameObject")]
    public GameObject myCanvas;

    private void OnTriggerEnter(Collider other)
    {
        myCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        myCanvas.SetActive(false);
    }
}