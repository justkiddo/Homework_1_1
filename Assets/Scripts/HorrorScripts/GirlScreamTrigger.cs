using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlScreamTrigger : MonoBehaviour
{
    
    [SerializeField] private AudioSource help;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            help.Play();
        }
    }
}
