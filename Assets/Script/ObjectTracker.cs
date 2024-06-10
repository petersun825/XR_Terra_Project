using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    public static ObjectTracker Instance;
    public List<GameObject> trackedObjects;
    public float destructionTime =1f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DestoryNow()
    {
        Debug.Log("Destorying all objects in the list!");
        StartCoroutine(DestroyOverTime());
    }

    IEnumerator DestroyOverTime()
    {
        foreach (GameObject go in trackedObjects)
        {
            Destroy(go);
            yield return new WaitForSeconds(destructionTime / trackedObjects.Count);
        }
        trackedObjects.Clear();
    }


    public void AddToTracked(GameObject objectToAdd)
    {
        trackedObjects.Add(objectToAdd);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
