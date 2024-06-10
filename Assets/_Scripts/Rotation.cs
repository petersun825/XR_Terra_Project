using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform objectToFollow;
 
    public float followSpeed = 25;


    // Update is called once per frame
    void Update()
    {
        // var delta = objectToFollow.position - transform.position;
        // transform.position += delta * Time.deltaTime * followSpeed;
        transform.RotateAround(objectToFollow.transform.position, Vector3.up, followSpeed * Time.deltaTime);

    }
}
