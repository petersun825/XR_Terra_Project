using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScaleForever : MonoBehaviour
{
    public bool triggerBox;
    MeshRenderer rend;
    public float parameterValue = 1.5f;

  

    Color GenerateRandomColor()
    {
        return Random.ColorHSV();
    }

    void MoveUp(float passValue)
    {
        transform.position += Vector3.up * passValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerBox)
        {
            Debug.Log("Trigger Box was clicked.");
            triggerBox = false;
            rend.material.color = GenerateRandomColor();
            MoveUp(parameterValue);
        }
    }
}
