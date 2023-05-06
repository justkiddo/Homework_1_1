using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timerText;
    private float _timeLeft = 0f;
    private bool _timerOn = false;
    private float _timeFromStart;
    private bool _alreadyEntered = false;

 
    private void Update()
    {
        _timeFromStart = Time.time;
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            } else
            {
                _timeLeft = time;
                _timerOn = false;
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
