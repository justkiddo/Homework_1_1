using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

public class SlidersPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textX;
    [SerializeField] private TextMeshProUGUI textY;
    [SerializeField] private TextMeshProUGUI textScale;
    [SerializeField] private Slider sliderX;
    [SerializeField] private Slider sliderY;
    [SerializeField] private Slider sliderScale;
    [SerializeField] private GameObject cube;
    [SerializeField] private Button button;
    
    public void Awake()
    {
        sliderX.onValueChanged.AddListener(OnSliderChangedX);
        sliderY.onValueChanged.AddListener(OnSliderChangedY);
        button.onClick.AddListener(CubeInformationX);
        button.onClick.AddListener(CubeInformationY);
        sliderScale.onValueChanged.AddListener(OnSliderChangeScale);
    }

    private void OnSliderChangedX(float value)
    {
        var rotation = value * 20;

        cube.transform.Rotate(rotation,0,0);
    }
    private void OnSliderChangedY(float value)
    {
        var rotation = value * 20;
        cube.transform.Rotate(0,rotation,0);

    }

    
    private void OnSliderChangeScale(float value)
    {
        var scaling = value * 50;
        cube.transform.localScale = new Vector3(scaling,scaling,scaling);

    }

    private void CubeInformationX()
    {
        textX.text = cube.transform.rotation.x.ToString();
    }
    private void CubeInformationY()
    {
        textY.text = cube.transform.rotation.y.ToString();
    }
    
}
