using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject spawnPrefab = Instantiate(prefabToSpawn, spawnLocation.transform.position, spawnLocation.transform.rotation);
            spawnPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
