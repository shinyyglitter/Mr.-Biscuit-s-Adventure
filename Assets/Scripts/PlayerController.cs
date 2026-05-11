using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 7.0f;
    private float turnSpeed = 100.0f;
    //Endre denne for hopphøyden
    private float jumpForce = 80.0f;
    private bool isGrounded;
    private float horizontalInput;
    private float verticalInput;
    public Animator animator;
    private Rigidbody playerRb;
    public PointManager pm;
    public GameManager gameManager;
    public  float behindDistance = 0.00001f;

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

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -7f, 7f),
            transform.position.y,
            transform.position.z
        );

        if(transform.position.z < -behindDistance)
        {
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
        gameManager.GameOver();
        }
    }

    void FixedUpdate()
    {
        if (!gameManager.isGameActive) return;

        Vector3 move = transform.forward * verticalInput * speed;
        Vector3 targetVelocity = transform.forward * verticalInput * speed;
    
        playerRb.linearVelocity = new Vector3(targetVelocity.x + playerRb.linearVelocity.x * 0f, playerRb.linearVelocity.y, targetVelocity.z + playerRb.linearVelocity.z * 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            pm.pointCount++;
            Destroy(other.gameObject);
        }
    }
    public void StopAnimation()
    {
        animator.enabled = false;
        playerRb.linearVelocity = Vector3.zero;
        enabled = false;
    }
}
