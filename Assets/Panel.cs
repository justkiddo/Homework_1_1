using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

public class Panel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Slider sliderX;
    [SerializeField] private Slider sliderY;
    [SerializeField] private Slider sliderScale;
    [SerializeField] private GameObject cube;
    [SerializeField] private Panel panel;
    [SerializeField] private Button button;
    public void Awake()
    {
        sliderX.onValueChanged.AddListener(OnSliderChangedX);
        sliderY.onValueChanged.AddListener(OnSliderChangedY);
        button.onClick.AddListener(CubeInformation);
        sliderScale.onValueChanged.AddListener(OnSliderChangeScale);
    }

    private void OnSliderChangedX(float value)
    {
        var rotation = value * 360;

        cube.transform.Rotate(rotation,0,0);
    }
    private void OnSliderChangedY(float value)
    {
        var rotation = value * 360;
        //cube.transform.localRotation = Quaternion.Euler(0,rotation,0);
        cube.transform.Rotate(0,rotation,0);

    }

    private void OnSliderChangeScale(float value)
    {
        var scaling = value * 100;
        cube.transform.localScale = new Vector3(scaling,scaling,scaling);

    }

    private void CubeInformation()
    {
        text.text = cube.transform.rotation.ToString();
    }

    
    
}
