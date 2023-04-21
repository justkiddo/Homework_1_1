using UnityEngine;
using Slider = UnityEngine.UI.Slider;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField, HideInInspector] private Rigidbody rb;
    
    [Range(5,100)]
    [SerializeField] private float movementSpeed = 5;
    [Range(1,20)]
    [SerializeField] private float rotateSpeed = 5;
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

    private void Awake()
    {
        shootingAngleSlider.onValueChanged.AddListener(onShottingAngleChange);
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        
        rb.angularVelocity = horizontal * rotateSpeed * transform.up;
        rb.velocity = vertical * movementSpeed * -transform.forward;
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

    private void onShottingAngleChange(float value)
    {
        var scaling = value * 1.01f;
        rb.transform.Rotate(scaling,0,0);
    }


}
