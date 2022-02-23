using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class MapZooming : MonoBehaviour
{
    /// <summary>
    /// The slider that lets the user control map zoom magnification.
    /// </summary>
    public PinchSlider zoomSlider;

    /// <summary>
    /// Unscaled Map transform
    /// </summary>
    public Transform mapRaw;

    private float minScale = 1;
    private float maxScale = 5;


    // Start is called before the first frame update
    void Start()
    {
        zoomSlider.OnValueUpdated.AddListener(OnSliderValueUpdate);
    }

    private void OnSliderValueUpdate(SliderEventData eventData)
    {
        Debug.Log("Slider value update: " + zoomSlider.SliderValue);
        float mapWidthScale = Mathf.Lerp(minScale, maxScale, zoomSlider.SliderValue);
        mapRaw.localScale = new Vector3(mapWidthScale, mapWidthScale, 1);
    }
}
