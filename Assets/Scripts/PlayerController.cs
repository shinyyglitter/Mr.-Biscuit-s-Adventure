using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 45.0f;
    private float jumpForce = 5.0f;
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

    isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

    bool isWalking = horizontalInput != 0 || verticalInput != 0;
    animator.SetBool("Walking", isWalking);
    animator.SetBool("Idle", !isWalking);

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("Jumping");
    }
}

void FixedUpdate()
{
    Vector3 movement = transform.forward * verticalInput * speed;
    Rb.linearVelocity = new Vector3(movement.x, Rb.linearVelocity.y, movement.z);

    Quaternion turn = Quaternion.Euler(Vector3.up * turnSpeed * horizontalInput * Time.fixedDeltaTime);
    Rb.MoveRotation(Rb.rotation * turn);
}

void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
}
}
