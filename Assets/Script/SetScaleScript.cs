using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScaleScript : MonoBehaviour
{
    public Vector3 setScale = new Vector3 (1, 1, 1);
    public Transform otherTransform;
    public bool triggerBox;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        otherTransform.localScale += setScale*Time.deltaTime;
        if (triggerBox){
            Debug.Log("Triggered:" + Time.deltaTime);
        }
    }
}
