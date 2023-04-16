using UnityEngine;
using Slider = UnityEngine.UI.Slider;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField, HideInInspector] private Rigidbody rb;
    
    [Range(5,100)]
    [SerializeField] private float movementSpeed = 5;
    [Range(5,100)]
    [SerializeField] private float rotateSpeed = 5;
    [Range(1000f,10000f)]
    [SerializeField] private float bulletSpeed = 1000f;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Slider shootingAngleSlider;
    
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
            GameObject _bullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            _bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * bulletSpeed, ForceMode.Force);
        }
    }

    private void onShottingAngleChange(float value)
    {
        var scaling = value * 2;
        rb.transform.Rotate(scaling,0,0);
    }
    
}
