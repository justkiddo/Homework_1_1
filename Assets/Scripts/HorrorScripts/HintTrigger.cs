using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject pentLamp;
    [SerializeField] private GameObject nextHint;
    private bool _oneTimeActive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(true);
            if (_oneTimeActive == false)
            {
                pentLamp.SetActive(true);
            }

            _oneTimeActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(false);
            nextHint.SetActive(true);
        }
    }
}
