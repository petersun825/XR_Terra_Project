using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class SocketPainter : MonoBehaviour
{
    // Start is called before the first frame update
    SocketSpawner socketSpawner;
    public Material newMaterial;
    void Start()
    {
        socketSpawner = GetComponent <SocketSpawner>();
    }

    public void ChangeMaterial(Material newMaterial)
    {
        if (socketSpawner.currentlyHeldPrefab != null) {
            Debug.Log("Change Material to " + newMaterial);
            socketSpawner.currentlyHeldPrefab.GetComponent<MeshRendererReference>().primaryMeshRenderer.material = newMaterial;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/

public class SocketPainter : MonoBehaviour
{
    SocketSpawner socketSpawner;
    public Material newMaterial;
    public Material newColor;

    void Start()
    {
        socketSpawner = GetComponent<SocketSpawner>();
    }

    public void ChangeMaterialColor(Material newColor)
    {
        if (socketSpawner.currentlyHeldPrefab != null)
        {
            Debug.Log("Change Color to " + newColor);
            SkinnedMeshRenderer skinnedRenderer = socketSpawner.currentlyHeldPrefab.GetComponentInChildren<SkinnedMeshRenderer>();

            if (skinnedRenderer != null)
            {

                Material[] materials = skinnedRenderer.materials;
                foreach (Material mat in materials)
                {
                    mat.SetColor("_BaseColor", newColor.color);
                }
                Debug.Log("SkinnedMeshRenderer base color changed to " + newColor);

            }
        }
    }

    public void ChangeMaterial(Material newMaterial)
    {
        if (socketSpawner.currentlyHeldPrefab != null)
        {
            Debug.Log("Change Material to " + newMaterial.name);
            MeshRenderer meshRenderer = socketSpawner.currentlyHeldPrefab.GetComponent<MeshRenderer>(); 

            
             if (meshRenderer != null)
            {
                meshRenderer.material= newMaterial;
                Debug.Log("MeshRenderer = " + newMaterial);
            }
            else
            {
                Debug.LogError("No SkinnedMeshRenderer or MeshRenderer found on the currently held prefab.");
            }
        }
        else
        {
            Debug.LogWarning("No currently held prefab found.");
        }
    }

    void Update()
    {
        // Update logic if needed
    }
}
