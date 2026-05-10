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
    public PointManager pm;
    public GameManager gameManager;

    void Start()
    {
       animator = GetComponent<Animator>();
       playerRb = GetComponent<Rigidbody>();

       playerRb.freezeRotation = true;
       gameManager = FindAnyObjectByType<GameManager>();
       pm.pointCount = 0;
       
    }

    // Update is called once per frame
   void Update()
    {
        if (!gameManager.isGameActive) return;
        
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
    bool isWalking = horizontalInput != 0 || verticalInput != 0;
    animator.SetBool("Walking", isWalking);
    animator.SetBool("Idle", !isWalking);
    
    if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}

    void FixedUpdate()
    {
    Vector3 move = transform.forward * verticalInput * speed;
    Vector3 targetVelocity = transform.forward * verticalInput * speed;

    playerRb.linearVelocity = new Vector3(targetVelocity.x + playerRb.linearVelocity.x * 0f, playerRb.linearVelocity.y, targetVelocity.z + playerRb.linearVelocity.z * 0f);
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
        if (!gameManager.isGameActive) return;

        Vector3 move = transform.forward * verticalInput * speed;
        playerRb.linearVelocity = new Vector3(move.x, playerRb.linearVelocity.y, move.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            pm.pointCount++;
            Destroy(other.gameObject);
            
        }
    }

}
