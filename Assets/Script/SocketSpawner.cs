using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSpawner : MonoBehaviour
{
    public GameObject currentlyHeldPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Currently held prefab is:" + currentlyHeldPrefab.name);
    }

    public void SpawnPrefab(GameObject prefabToSpawn)
    {
        
        Debug.Log("Spawning prefab now!");
        if (currentlyHeldPrefab != null)
        {
            Debug.Log("Prefab cannot spawn b/c of : " + currentlyHeldPrefab.name);
            ObjectTracker.Instance.trackedObjects.Remove(currentlyHeldPrefab);
            Destroy(currentlyHeldPrefab);
        }
       
        
            currentlyHeldPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            Debug.Log("Currently Held Prefab = " + prefabToSpawn);
        
    }
    public void ReleaseHeld()
    {
        Debug.Log("Released Object from prefab");
        currentlyHeldPrefab = null;
    }
    public void RegisterHeld(SelectEnterEventArgs args)
    {
        currentlyHeldPrefab = args.interactableObject.transform.gameObject;
    }
}
