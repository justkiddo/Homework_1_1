using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class MovementForPlayer : MonoBehaviour
{
    [HideInInspector] [SerializeField] private CharacterController _movement;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private Animator animator;
    private Vector3 _velocity = Vector3.zero;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int Movespeed = Animator.StringToHash("Movespeed");
    private static readonly int Punch = Animator.StringToHash("Punch");


    private void OnValidate()
    {
        _movement = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseX = Input.GetAxis("Mouse X");
        var jump = Input.GetAxis("Jump");

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(Punch);
        }
        
        
        RotateCharacter(horizontal);
        Moving(horizontal, vertical, jump);
    }

    private void RotateCharacter(float rotate)   
    {
       // transform.Rotate(Vector3.up, rotate);
        transform.Rotate(0, rotate, 0 );
    }

    private void Moving(float horizontal, float vertical, float jump)
    {
        var runMultiplication =  (Input.GetKey(KeyCode.LeftShift)) ? 2 : 1;
  

        var dir = new Vector3(horizontal, 0, vertical);
        var speed = runMultiplication * moveSpeed;
       
        var moveVector = transform.TransformDirection(dir) * speed;
        
        animator.SetBool(IsWalking, horizontal != 0 || vertical !=0);
        animator.SetBool(IsJumping, jump != 0);
        animator.SetFloat(Movespeed, speed / (moveSpeed * 2 ));
        
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
