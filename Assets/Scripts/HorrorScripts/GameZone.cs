using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameZone : MonoBehaviour
{

    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Animator animator;
    private static readonly int IsGameOver = Animator.StringToHash("IsGameOver");


    private void Update()
    {
        if (animator.GetBool(IsGameOver))
        {
            timer.enabled = false;
            timerText.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            endGameMenu.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool(IsGameOver, true);
        }
    }
}
