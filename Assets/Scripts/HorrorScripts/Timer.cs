using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private FirstPersonMovement fpm;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private AudioSource stepsSound;
    private float _timeLeft;
    private bool _timerOn;
    private float _timeFromStart;
    private bool _alreadyEntered;
    private static readonly int IsGameOver = Animator.StringToHash("IsGameOver");


    private void Update()
    {
        _timeFromStart = Time.timeSinceLevelLoad;
        
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            } else
            {
                fpm.enabled = false;
                animator.SetBool(IsGameOver, true);
                endGameMenu.SetActive(true);
                stepsSound.Stop();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        
        timerText.text = $"{minutes:00} : {seconds:00}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _alreadyEntered == false)
        {
            _timerOn = true;
            _alreadyEntered = true;
            _timeLeft = _timeFromStart;
        }
    }
}
