using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 45.0f;
    //Endre denne for hopphøyden
    private float jumpForce = 50.0f;
    private bool isGrounded;
    private float horizontalInput;
    private float verticalInput;
    public Animator animator;
    private Rigidbody playerRb;

    void Start()
    {
       animator = GetComponent<Animator>();
       playerRb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
   void Update()
{
    horizontalInput = Input.GetAxis("Horizontal");
    verticalInput = Input.GetAxis("Vertical");

    transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

   
    if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    bool isWalking = horizontalInput != 0 || verticalInput != 0;
    animator.SetBool("Walking", isWalking);
    animator.SetBool("Idle", !isWalking);
}
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void FixedUpdate()
    {
    Vector3 move = transform.forward * verticalInput * speed;
    playerRb.linearVelocity = new Vector3(move.x, playerRb.linearVelocity.y, move.z);
    }

    private void OnEnterTrigger(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            Destroy(other.gameObject);
        }
    }

}
