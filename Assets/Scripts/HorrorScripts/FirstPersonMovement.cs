using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _movement;
    [SerializeField] private AudioSource stepsSound;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private new GameObject light;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private Animator _animator;
    [Range(0.1f, 1 )]
    [SerializeField] private float rotateSpeed = 0.4f;
    private Vector3 _velocity = Vector3.zero;
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;
    private float _xRotation = 0.0f;
    private float _yRotation = 0.0f;
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        var mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
        var horizontal = Input.GetAxis("Horizontal") * rotateSpeed;
        var vertical = Input.GetAxis("Vertical");
        var jump = Input.GetAxis("Jump");
        
        RotateCharacter(mouseX);
        Moving(horizontal, vertical, jump);
        StepsSoundSpeed();
        StepsSound();
        CameraRotationLogic(mouseX, mouseY);
    }

    private void CameraRotationLogic(float mouseX, float mouseY)
    {
        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        _cam.transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0.0f);
        light.transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0.0f);
    }

    private void StepsSoundSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stepsSound.pitch = 2;
        }
        else
        {
            stepsSound.pitch = 1;
        }
    }

    private void StepsSound()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f ||
            Mathf.Abs(Input.GetAxis("Vertical")) > 0.35f && _movement.isGrounded)
        {
            if (stepsSound.isPlaying) return;
            stepsSound.Play();
        }
        else
        {
            stepsSound.Stop();
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
                _animator.SetBool("Jump", true);
                jumpSound.Play();
                _velocity.y += jumpForce;
            }
        }
        _velocity.y += -9.81f * Time.deltaTime;
        _movement.Move((moveVector + _velocity) * Time.deltaTime);
    }
    
}