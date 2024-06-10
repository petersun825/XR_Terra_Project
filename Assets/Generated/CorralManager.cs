using System.Collections;
using UnityEngine;

public class CorralManager : MonoBehaviour
{
    // Exposed GameObjects
    [Tooltip("First GameObject to be placed")]
    public GameObject objectOne;
    [Tooltip("Second GameObject to be placed")]
    public GameObject objectTwo;
    [Tooltip("Third GameObject to be placed")]
    public GameObject objectThree;

    // Terrain and Water Colliders
    private TerrainCollider terrainCollider;
    private BoxCollider waterCollider;
    private const int numberOfObjects = 150;

    private void Start()
    {
        // Get the terrain collider
        terrainCollider = GameObject.FindObjectOfType<TerrainCollider>();
        // Get the water collider
        waterCollider = GameObject.Find("WaterCollider").GetComponent<BoxCollider>();

        if (terrainCollider != null && waterCollider != null)
        {
            // Start coroutine to place objects
            StartCoroutine(PlaceObjects());
        }
    }

    private IEnumerator PlaceObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Place objects
            PlaceObject(objectOne);
            PlaceObject(objectTwo);
            PlaceObject(objectThree);

            // Wait for next frame to place next objects
            yield return null;
        }
    }

    private void PlaceObject(GameObject objectToPlace)
    {
        // Get random position on terrain
        Vector3 randomPosition = new Vector3(Random.Range(0, terrainCollider.bounds.size.x), 3, Random.Range(0, terrainCollider.bounds.size.z));

        // Get the position on the terrain below the random position
        if (Physics.Raycast(randomPosition, Vector3.down, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
        {
            // Check if the hit point is within the water collider
            if (waterCollider.bounds.Contains(hit.point))
            {
                // Instantiate object at hit position
                Instantiate(objectToPlace, hit.point+new Vector3(0,0.5f,0), Quaternion.identity);
            }
        }
    }
}