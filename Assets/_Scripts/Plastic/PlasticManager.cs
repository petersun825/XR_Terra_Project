using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject binPrefab;
    public GameObject stuffPrefab;
    [SerializeField] public static int tankSize = 50;
  

    static int numFish = 100;
    static int numBin = 100;
    static int numStuff = 15;
    public static GameObject[] allFish = new GameObject[numFish];
    public static GameObject[] allBin = new GameObject[numBin];
    public static GameObject[] allStuff = new GameObject[numStuff];

    public static Vector3 goalPos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(-40 + Random.Range(-tankSize,  tankSize),
                                        Random.Range(-tankSize, tankSize),
                                        Random.Range( -tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
        for (int i = 0; i < numBin; i++)
        {
            Vector3 pos = new Vector3(-40 + Random.Range(-tankSize , tankSize),
                                        Random.Range(-tankSize, tankSize),
                                        Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(binPrefab, pos, Quaternion.identity);
        }
        for (int i = 0; i < numStuff; i++)
        {
            Vector3 pos = new Vector3(-40 + Random.Range(-tankSize , tankSize),
                                        Random.Range(-tankSize, tankSize),
                                        Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(stuffPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 500)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                            Random.Range(-tankSize, tankSize),
                            Random.Range(-tankSize, tankSize));
            //goalPrefab.transform.position = goalPos;
        }
    }
}
