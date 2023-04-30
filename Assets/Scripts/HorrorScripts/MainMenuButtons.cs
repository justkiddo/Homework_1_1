using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button exitGameButton;
    [SerializeField] private Button startButton;


    private void Awake()
    {
        startButton.onClick.AddListener(HorrorLoadScenes.StartGame);
        exitGameButton.onClick.AddListener(HorrorLoadScenes.ExitGame);
    }
}
