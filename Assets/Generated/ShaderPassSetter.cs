using UnityEngine;

public class ShaderPassSetter : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Index of the shader pass for Aquas_Lite_Water")]
    private int aquasLiteWaterPassIndex = 0;

    [SerializeField]
    [Tooltip("Index of the shader pass for Aquas_Lite_Water_Backface")]
    private int aquasLiteWaterBackfacePassIndex = 0;

    private void Start()
    {
        // Get the Renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Find the materials in the renderer's materials array
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            // If the material's name contains "Aquas_Lite_Water", set the shader pass
            if (renderer.materials[i].name.Contains("Aquas_Lite_Water"))
            {
                renderer.materials[i].SetPass(aquasLiteWaterPassIndex);
            }

            // If the material's name contains "Aquas_Lite_Water_Backface", set the shader pass
            if (renderer.materials[i].name.Contains("Aquas_Lite_Water_Backface"))
            {
                renderer.materials[i].SetPass(aquasLiteWaterBackfacePassIndex);
            }
        }
    }
}