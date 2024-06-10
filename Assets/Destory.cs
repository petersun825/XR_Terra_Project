using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Destroy : MonoBehaviour
{
    private XRSocketInteractor socketInteractor;

    void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(DestroyInteractable);
    }

    public void DestroyInteractable(SelectEnterEventArgs arg)
    {
        if (arg.interactable != null)
        {
            Destroy(arg.interactable.gameObject);
        }
    }

    void OnDestroy()
    {
        // Make sure to remove the listener when this GameObject is destroyed to avoid memory leaks
        socketInteractor.selectEntered.RemoveListener(DestroyInteractable);
    }
}
