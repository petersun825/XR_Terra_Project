using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationFloat : MonoBehaviour
{
    Animator animator;
    public string parameterName;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetSpeed(float newSpeed)
    {
        animator.SetFloat(parameterName, newSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
