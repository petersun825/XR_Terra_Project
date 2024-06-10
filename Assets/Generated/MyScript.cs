using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyScript : MonoBehaviour
{
    [Tooltip("Reference to the TextMeshProUGUI component")]
    public TMP_Text text;

    [Tooltip("Reference to the Slider component")]
    public Slider slider;



    // Start is called before the first frame update
    void Start()
    {
        // Set the slider's minimum and maximum values
        slider.minValue = 1;
        slider.maxValue = 30;

        // Add a listener to the slider's value changed event
        slider.onValueChanged.AddListener(OnSliderValueChanged);

  
    }

    // Update the text when the slider value changes
    void OnSliderValueChanged(float value)
    {
        text.text = "I'll chip in: $"+value.ToString();
    }

   

    // Called when the button is clicked
    public void onClickDonate()
    {
        text.text = "Thank you!";
    }
}