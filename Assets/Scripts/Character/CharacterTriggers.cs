using System;
using UnityEngine;


public class CharacterTriggers : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MovementForPlayer _movementForPlayer;
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool(IsDead, true);

            _movementForPlayer.enabled = false;
            

    }
}
