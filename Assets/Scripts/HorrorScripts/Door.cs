using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorAxisEnum {X, Y, Z}; // Z
    public DoorAxisEnum doorAxis;
    private bool _isOpen;
    [SerializeField] private float openSpeed = 150f;
    [SerializeField] private float openAngle = 140f;
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    private bool _openCloseOn;
    private float _startDistOrAngle;
    private Quaternion _startRot;
    

    private void Start()
    {
        var localEulerAngles = transform.localEulerAngles;
        _startDistOrAngle = doorAxis switch
        {
            DoorAxisEnum.X => localEulerAngles.x,
            DoorAxisEnum.Y => localEulerAngles.y,
            DoorAxisEnum.Z => localEulerAngles.z,
            _ => _startDistOrAngle
        };
    }

    private void OnMouseDown()
    {
        OpenClose();
    }

    private void OpenClose()
    {
        _openCloseOn = true;
        if (_isOpen) _isOpen = false;
        else
        {
            _isOpen = true;
            if(openSound) openSound.Play();
            
        }
    }

    private void Update()
    {
        if (_openCloseOn)
        {
            if (_isOpen)
            {
                if (doorAxis == DoorAxisEnum.X)
                {
                    var posX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, _startDistOrAngle + openAngle,
                        openSpeed * Time.deltaTime);
                    transform.localEulerAngles =
                        new Vector3(posX, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    if (transform.localEulerAngles.x == _startDistOrAngle + openAngle) StopOpenClose();
                }
                else if (doorAxis == DoorAxisEnum.Y)
                {
                    var posY = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, _startDistOrAngle + openAngle,
                        openSpeed * Time.deltaTime);
                    transform.localEulerAngles =
                        new Vector3(transform.localEulerAngles.x, posY, transform.localEulerAngles.z);
                    if (transform.localEulerAngles.y == _startDistOrAngle + openAngle) StopOpenClose();
                }
                else if (doorAxis == DoorAxisEnum.Z)
                {
                    var posZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, _startDistOrAngle + openAngle,
                        openSpeed * Time.deltaTime);
                    transform.localEulerAngles =
                        new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, posZ);
                    if (transform.localEulerAngles.z == _startDistOrAngle + openAngle) StopOpenClose();
                }
            }
            else
            {
                if (doorAxis == DoorAxisEnum.X)
                {
                    float angleX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, _startDistOrAngle,
                        openSpeed * Time.deltaTime);
                    transform.localEulerAngles = new Vector3(angleX, 0, 0);
                    if (transform.localEulerAngles.x == _startDistOrAngle) StopOpenClose(); 
                } else if(doorAxis == DoorAxisEnum.Y)
                {
                    float angleY = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, _startDistOrAngle,
                        openSpeed * Time.deltaTime);
                    transform.localEulerAngles = new Vector3(0, angleY, 0);
                    if (transform.localEulerAngles.y == _startDistOrAngle) StopOpenClose(); 
                }else if(doorAxis == DoorAxisEnum.Z)
                {
                    float angleZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, _startDistOrAngle,
                        openSpeed * Time.deltaTime);
                    transform.localEulerAngles = new Vector3(0, 0, angleZ);
                    if (transform.localEulerAngles.z == _startDistOrAngle) StopOpenClose(); 
                }
            }
        }
    }

    private void StopOpenClose()
    {
        _openCloseOn = false;
        if(closeSound && !_isOpen) closeSound.Play();
    }
}
