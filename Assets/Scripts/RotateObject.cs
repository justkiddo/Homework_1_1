using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float x, y, z;
    private float _speed = 0.03f;
    void Update()
    {
        transform.Rotate(x * _speed,y * _speed,z * _speed);
        
    }
}
