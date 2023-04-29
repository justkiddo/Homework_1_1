using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [HideInInspector] [SerializeField] private CharacterController _movement;
    [SerializeField] private AudioSource steps;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 6f;
    [Range(0.1f, 1 )]
    [SerializeField] private float rotateSpeed = 0.4f;
    private Vector3 _velocity = Vector3.zero;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int Movespeed = Animator.StringToHash("Movespeed");


    private void OnValidate()
    {
        _movement = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotateSpeed;
        var vertical = Input.GetAxis("Vertical");
        var mouseX = Input.GetAxis("Mouse X");
        var jump = Input.GetAxis("Jump");

        RotateCharacter(horizontal);
        Moving(horizontal, vertical, jump);
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f)
        {
            if (steps.isPlaying) return;
            steps.Play();
        }
        else
        {
            steps.Stop();
        }
        
    }

    private void RotateCharacter(float rotate)
    {
        transform.Rotate(0, rotate, 0 );
    }

    private void Moving(float horizontal, float vertical, float jump)
    {
        var runMultiplication =  (Input.GetKey(KeyCode.LeftShift)) ? 2 : 1;
        

        var dir = new Vector3(horizontal, 0, vertical);
        var speed = runMultiplication * moveSpeed;
        
        var moveVector = transform.TransformDirection(dir) * speed;

        if (_movement.isGrounded)
        {
            if(_velocity.y < 0)
            {
                _velocity.y = 0f;
            }
            if (jump != 0 )
            {
                _velocity.y += jumpForce;
            }
        }
        _velocity.y += -9.81f * Time.deltaTime;
        _movement.Move((moveVector + _velocity) * Time.deltaTime);
    }
    
}
