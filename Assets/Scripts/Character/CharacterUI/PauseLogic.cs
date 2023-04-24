using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _continueButton;
    
    private void Awake()
    {
        panel.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }


    
    private void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Unpause()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
