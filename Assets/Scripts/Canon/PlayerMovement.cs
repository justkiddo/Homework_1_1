using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Range = UnityEngine.SocialPlatforms.Range;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField, HideInInspector] private Rigidbody rb;
    
    [Range(5,100)]
    [SerializeField] private float movementSpeed = 5;
    [Range(5,100)]
    [SerializeField] private float rotateSpeed = 5;
    [Range(5000f,10000f)]
    [SerializeField] private float bulletSpeed = 5000f;
    
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;
    
    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
 
        rb.angularVelocity = horizontal * rotateSpeed * transform.up;
        rb.velocity = vertical * movementSpeed * -transform.forward;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _bullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            _bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * bulletSpeed, ForceMode.Force);
        }
    }
}
