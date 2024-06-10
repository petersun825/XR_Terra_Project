using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetColor1 : MonoBehaviour
{
    public FollowAlongLocalX slider;
    Vector3 startingRotation;
    private Renderer objectRenderer;
    private Renderer objectRenderer2;
    public GameObject objectColorChange; //change color of a object
    public Material materialColorChange; //change color of a material
    public GameObject buttonColorChange;

    // Start is called before the first frame update
    void Start()
    {
      
        
     
        if (materialColorChange != null) {
            objectRenderer = objectColorChange.GetComponent<Renderer>(); // retrieve a renderer component from the game object referred to by target object 
            objectRenderer2 = buttonColorChange.GetComponent<Renderer>();
            

            if (objectRenderer == null)
            {
                Debug.LogError("Renderer component missing from the object!");
            }

        }
        else
        {
            Debug.LogError("Target object is not assigned!");
        }
       

    }

    // Update is called once per frame
    void Update()
    {
   

        //change the color based on the rotation
        if (objectRenderer != null && materialColorChange != null)
        {
            float colorIntensity = Mathf.Abs(slider.sliderOutputValue) / 360;
            Color newColor = new Color(colorIntensity, 0.5f, 0.5f);
            objectRenderer.material.color = newColor; //change object's color
            materialColorChange.color = newColor; //change material for the color setting
            objectRenderer2.material.color = newColor; //set button color


        }
    }
}
