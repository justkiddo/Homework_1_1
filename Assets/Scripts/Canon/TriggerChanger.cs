using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChanger : MonoBehaviour
{
    [SerializeField] private GameObject shootingTarget;
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("leaving area");

        if (shootingTarget == other.gameObject)
        {
            Debug.Log("target leaving area");
        }
        
    }
}
