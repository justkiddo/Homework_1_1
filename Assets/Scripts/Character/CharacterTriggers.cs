using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggers : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool(IsDead, true);
    }
}
