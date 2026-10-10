using UnityEngine;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour
{
    public Slider brightness;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetSlider();

        brightness.onValueChanged.AddListener((bright) => ChangeBrightness(bright));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetSlider()
    {
        float bright = PlayerPrefs.HasKey("Brightness") ? PlayerPrefs.GetFloat("Brightness") : 1f;

        brightness.value = bright;
    }

    public void ChangeBrightness(float bright)
    {
        BrightnessManager.instance.SetBrightness(bright);
    }
}
