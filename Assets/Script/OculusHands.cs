using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OculusHands : MonoBehaviour
{
    Animator animator;
    public InputActionReference gripReference, triggerReference;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        gripReference.action.started += GripPressed;
        gripReference.action.started += GripCanceled;
        triggerReference.action.started += TriggerPressed;
        triggerReference.action.started += TriggerCanceled;
    }

    private void OnDestory()
    {
        gripReference.action.started -= GripPressed;
        gripReference.action.started -= GripCanceled;
        triggerReference.action.started -= TriggerPressed;
        triggerReference.action.started -= TriggerCanceled;
    }
     void GripPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Grip was pressed!");
    }
    void GripCanceled (InputAction.CallbackContext context)
    {
        Debug.Log("Grip was released!");
    }

    void TriggerPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger was pressed!");
    }
    void TriggerCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger was released!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
