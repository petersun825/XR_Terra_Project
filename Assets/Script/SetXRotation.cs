using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetXRotation : MonoBehaviour
{
    public FollowAlongLocalX slider;
    Vector3 startingRotation;
    // Start is called before the first frame update
    void Start()
    {
        startingRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotationVector = startingRotation;
        newRotationVector.x = slider.sliderOutputValue;
        transform.rotation = Quaternion.Euler(newRotationVector);
    }
}
