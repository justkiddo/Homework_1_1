using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class ColorChangePanel : MonoBehaviour
{

    [SerializeField] private GameObject inGameObject;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Dropdown dd;
    private static readonly int Color1 = Shader.PropertyToID("_Color");


    private void Start()
    {
        button.onClick.AddListener(ButtonChangeColor);
    }

    
    private void ButtonChangeColor()
    {
        var objectRenderer = inGameObject.GetComponent<Renderer>();
        objectRenderer.material.SetColor(Color1, Color.blue);
    }
    

    
    
    
}
