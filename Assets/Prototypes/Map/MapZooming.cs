using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class MapZooming : MonoBehaviour
{
    public PinchSlider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.OnValueUpdated.AddListener(OnSliderValueUpdate);
    }

    private void OnSliderValueUpdate(SliderEventData eventData)
    {
        Debug.Log("Slider value update: " + slider.SliderValue);
    }
}
