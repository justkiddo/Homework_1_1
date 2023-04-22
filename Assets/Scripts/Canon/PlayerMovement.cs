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
       
    }




}
