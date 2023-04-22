using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class MovementForPlayer : MonoBehaviour
{
    [HideInInspector] [SerializeField] private CharacterController _movement;
    [SerializeField] private float moveSpeed = 10f;
    private Vector3 _velocity = Vector3.zero;
    private void OnValidate()
    {
        _movement = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        var jump = Input.GetAxis("Jump");
        RotateCharacter(mouseX, mouseY);
        Moving(horizontal, vertical);
    }

    private void RotateCharacter(float mouseX, float mouseY)
    {
        transform.Rotate(Vector3.up, mouseX );
        transform.Rotate(Vector3.left, mouseY);
    }

    private void Moving(float horizontal, float vertical)
    {
        var dir = new Vector3(horizontal, 0, vertical);
        var moveVector = transform.TransformDirection(dir) * moveSpeed;
        
        if (_movement.isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        _velocity.y += -9.81f * Time.deltaTime;
        
        _movement.Move((moveVector + _velocity) * Time.deltaTime);
    }
}
