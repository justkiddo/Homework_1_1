using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject winCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winCanvas.SetActive(true);
            timer.enabled = false;
            timerText.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
