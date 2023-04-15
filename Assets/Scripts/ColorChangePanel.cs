using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(MeshRenderer))]

public class ColorChangePanel : MonoBehaviour
{

    [SerializeField] private GameObject inGameObject;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Dropdown dd;
    private MeshRenderer _mesh;


    private void Start()
    {
       button.onClick.AddListener(ButtonChangeColor);
    }

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }


    private void ButtonChangeColor()
    {
        var objectRenderer = inGameObject.GetComponent<Renderer>();
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        materialPropertyBlock.SetColor("_Color", Color.green);
        objectRenderer.SetPropertyBlock(materialPropertyBlock);

       // _mesh.SetPropertyBlock(materialPropertyBlock);
        
    }
    

    
    
    
}
