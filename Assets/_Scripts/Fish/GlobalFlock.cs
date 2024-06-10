/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject fishPrefab2;
    public GameObject waterCollider;
    [SerializeField] public static int tankSize = 8;

    static int numFish = 100;
    public static GameObject[] allFish = new GameObject[numFish];
    public static GameObject[] allFish2 = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<numFish; i++)
        {
            Vector3 pos = new Vector3(-40+Random.Range(-tankSize+5, 2*tankSize),
                                        Random.Range(-tankSize+5, tankSize),
                                        Random.Range(-2*tankSize, 2*tankSize));
            allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish2[i] = (GameObject)Instantiate(fishPrefab2, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000)< 500)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                            Random.Range(-tankSize, tankSize),
                            Random.Range(-tankSize, tankSize));
            //goalPrefab.transform.position = goalPos;
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject fishPrefab2;
    public Terrain terrain; // Public variable for the terrain
    public BoxCollider boxCollider; // Public variable for the box collider
    [SerializeField] public static int tankSize = 8;

    static int numFish = 500;
    public static GameObject[] allFish = new GameObject[numFish];
    //public static GameObject[] allFish2 = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Get terrain boundaries
        float terrainMinX = terrain.transform.position.x;
        float terrainMaxX = terrainMinX + terrain.terrainData.size.x;
        float terrainMinZ = terrain.transform.position.z;
        float terrainMaxZ = terrainMinZ + terrain.terrainData.size.z;

        // Get box collider boundaries
        Bounds boxBounds = boxCollider.bounds;
        Vector3 boxMin = boxBounds.min;
        Vector3 boxMax = boxBounds.max;

        for (int i = 0; i < numFish; i++)
        {
            // Generate random position within the boundaries
            Vector3 pos = new Vector3(
                Random.Range(Mathf.Max(terrainMinX, boxMin.x), Mathf.Min(terrainMaxX, boxMax.x)),
                Random.Range(boxMin.y, boxMax.y),
                Random.Range(Mathf.Max(terrainMinZ, boxMin.z), Mathf.Min(terrainMaxZ, boxMax.z))
            );

            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
           // allFish2[i] = (GameObject)Instantiate(fishPrefab2, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 500)
        {
            // Get box collider boundaries
            Bounds boxBounds = boxCollider.bounds;
            Vector3 boxMin = boxBounds.min;
            Vector3 boxMax = boxBounds.max;

            goalPos = new Vector3(
                Random.Range(boxMin.x, boxMax.x),
                Random.Range(boxMin.y, boxMax.y),
                Random.Range(boxMin.z, boxMax.z)
            );
        }
    }
}
