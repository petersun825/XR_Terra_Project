using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObject : MonoBehaviour
{
    //public ObjectTracker objectTracker;

 
    // Start is called before the first frame update
    void Start()
    {
        //   objectTracker.AddToTracked(gameObject);
        ObjectTracker.Instance.AddToTracked(gameObject);
    }
            
    // Update is called once per frame
    void Update()
    {
        
    }
}
