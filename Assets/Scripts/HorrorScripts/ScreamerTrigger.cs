using System;
using UnityEngine;

public class ScreamerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject screamer;
    [SerializeField] private GameObject flash;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            screamer.SetActive(true);
            flash.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            screamer.SetActive(false);
            flash.SetActive(false);
        }
    }
}
