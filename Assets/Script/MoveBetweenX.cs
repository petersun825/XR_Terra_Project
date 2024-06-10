
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenX : MonoBehaviour
{
    public float distance = 4f;
    public float moveSpeed = 2f;

    Vector3 _direction;
    float _xMin;
    float _xMax;
    Collider ballCollider;
   


    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector3.right;
        _xMin = transform.localPosition.x-distance;
        _xMax = transform.localPosition.x + distance;
         ballCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = _direction * moveSpeed * Time.deltaTime;
        transform.localPosition += movement;
        SetDirection(transform.localPosition.x);

    }

    void SetDirection(float currentXPosition)
    {
        if (currentXPosition > _xMax)
        {
            _direction = Vector3.left;
        }
        else if (currentXPosition < _xMin)
        {
            _direction = Vector3.right;
        }
    }
}
