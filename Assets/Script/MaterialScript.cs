using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    MeshRenderer rend;
    public Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.material.SetColor("_EmissionColor", Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newOffest = rend.material.GetTextureOffset("_MainTex");
        newOffest += Vector2.left * Time.deltaTime;
        rend.material.SetTextureOffset("_MainTex", newOffest);
    }
}
