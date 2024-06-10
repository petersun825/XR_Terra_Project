using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowAlongLocalX : MonoBehaviour
{
    public Transform grabbleTransform;
    public Transform visualTransform;
    public float outputMinimum = 100f;
    public float outputMaximum = 100f;
    public float sliderOutputValue;
    public float sliderLength = 4f;
    public float startingValue;
    // Start is called before the first frame update
    void Start()
    {
        float startingFraction = Mathf.InverseLerp(outputMinimum, outputMaximum, startingValue);
        float desiredLocalXPosition = Mathf.Lerp(0, sliderLength, startingFraction);
        grabbleTransform.localPosition = new Vector3(desiredLocalXPosition, 0, 0);
    }

    public void TeleportGrabbableToVisual()
    {
        grabbleTransform.position = visualTransform.position;
        grabbleTransform.rotation = visualTransform.rotation;
    }

    void SyncVisualToGrabbed()
    {
        //visualTransform.position = grabbleTransform.position;
        Vector3 newLocalPosition = transform.InverseTransformPoint(grabbleTransform.position);
        newLocalPosition.y = 0f;
        newLocalPosition.z = 0f;
        newLocalPosition.x = Mathf.Clamp(newLocalPosition.x, 0, sliderLength);
        visualTransform.localPosition = newLocalPosition;
    }
    public void TeleportGrabbleToVisual()
    {
        grabbleTransform.position = visualTransform.position;
        grabbleTransform.rotation = visualTransform.rotation;
    }
    void CalculateSliderValue()
    {
        float betweenZeroAndOne = Mathf.InverseLerp(0, sliderLength, visualTransform.localPosition.x);
        //Debug.Log("between 0 & 1 number is: " + betweenZeroAndOne);
        sliderOutputValue = Mathf.Lerp(outputMinimum, outputMaximum, betweenZeroAndOne);
    }
    // Update is called once per frame
    void Update()
    {
        SyncVisualToGrabbed();
        CalculateSliderValue();
    }
}
