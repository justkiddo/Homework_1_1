using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField, HideInInspector] private Rigidbody rb;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Slider shootingAngleSlider;
    [SerializeField] private float maxCanonPower = 10000f;
    [SerializeField] private float bulletSpeed = 1000f;
    private float startShooting, stoppedShooting;
    
    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startShooting = Time.time;
           
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            stoppedShooting = Time.time;
            var bulletPower = bulletSpeed * (stoppedShooting - startShooting);
            if (!(bulletPower < maxCanonPower)) return;
            GameObject _bullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            _bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * bulletPower, ForceMode.Force);
        }
    }

    private void Awake()
    {
        shootingAngleSlider.onValueChanged.AddListener(onShottingAngleChange);
    }
    
    
    
    private void onShottingAngleChange(float value)
    {
        var scaling = value * 1.01f;
        rb.transform.Rotate(scaling,0,0);
    }
    
    
    
}
