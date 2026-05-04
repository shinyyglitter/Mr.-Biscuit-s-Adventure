using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 45.0f;
    private float jumpForce;
    private float ySpeed;
    private bool isGrounded = true; // Grounded check for jumping
    private float horizontalInput;
    private float verticalInput;
    public Animator animator;
    private Rigidbody Rb;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>();
       Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   void Update()
{
    horizontalInput = Input.GetAxis("Horizontal");
    verticalInput = Input.GetAxis("Vertical");
    transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

    isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

    bool isWalking = horizontalInput != 0 || verticalInput != 0;
    animator.SetBool("Walking", isWalking);
    animator.SetBool("Idle", !isWalking);

    ySpeed += Physics.gravity.y * Time.deltaTime;

    
}



void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
}
}
