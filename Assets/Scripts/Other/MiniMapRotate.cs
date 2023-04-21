
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class MiniMapRotate : MonoBehaviour
{
    [SerializeField] private Button _buttonX;
    [SerializeField] private Button _buttonY;
    [SerializeField] private Button _buttonZ;
    [SerializeField] private GameObject gameObjectRotate;

    private void Awake()
    {
        _buttonX.onClick.AddListener(onButtonPressedX);
        _buttonY.onClick.AddListener(onButtonPressedY);
        _buttonZ.onClick.AddListener(onButtonPressedZ);
    }

    
    
    private void onButtonPressedX()
    {
        gameObjectRotate.transform.Rotate(90,0,0);
    }
    
    private void onButtonPressedY()
    {
        gameObjectRotate.transform.Rotate(0,90,0);
    }
    
    private void onButtonPressedZ()
    {
        gameObjectRotate.transform.Rotate(0,0,90);
    }
    
}
