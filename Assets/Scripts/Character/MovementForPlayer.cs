using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementForPlayer : MonoBehaviour
{
    [SerializeField, HideInInspector] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    private float movementSpeed = 2f;
    private float rotateSpeed = 1f;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        _rb.angularVelocity = horizontal * rotateSpeed * transform.up;
        _rb.velocity = vertical * movementSpeed * transform.forward;
        
    }
}
