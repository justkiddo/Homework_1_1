using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsCloseTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("PlayerIsNear", true);
            rb.useGravity = true;
        }
    }
}
