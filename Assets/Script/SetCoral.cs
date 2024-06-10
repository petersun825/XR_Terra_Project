using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCoral : MonoBehaviour
{
    public FollowAlongLocalX slider;
    public GameObject objectPrefab;
    public GameObject prefabCoral;
    public Transform spawnPlane;
    public int density = 5;

    private float spawnRate = 1f;
    private float lastSpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {

     
        
    }

    void SpawnObject()
    {
        for (int i = 0; i < density; i++)
        {
            // Determine random position within the bounds of the spawnPlane
            Vector3 planeSize = spawnPlane.GetComponent<Renderer>().bounds.size;
            Vector3 position = new Vector3(
                Random.Range(spawnPlane.position.x - planeSize.x / 2, spawnPlane.position.x + planeSize.x / 2),
                spawnPlane.position.y, // Adjust y position based on object height
                Random.Range(spawnPlane.position.z - planeSize.z / 2, spawnPlane.position.z + planeSize.z / 2)
            );
            //spawnPlane.position.y + objectPrefab.transform.localScale.y / 2 in case
            // Instantiate the object at the determined position
            Instantiate(objectPrefab, position, Quaternion.identity);
            Instantiate(prefabCoral, position, Quaternion.identity);
        }
    }
}
