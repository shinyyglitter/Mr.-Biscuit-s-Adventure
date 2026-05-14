using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 6.0f;
    private float turnSpeed = 120.0f;
    private float jumpForce = 100.0f;
    private bool isGrounded;
    private float horizontalInput;
    private float verticalInput;

    public Animator animator;
    private Rigidbody playerRb;
    public PointManager pm;
    public GameManager gameManager;
    public  float behindDistance = 0.00001f;
    public ParticleSystem particlesmoke;
    public ParticleSystem particleFight;

    void Start()
    {
       animator = GetComponent<Animator>();
       playerRb = GetComponent<Rigidbody>();

        playerRb.freezeRotation = true;
        gameManager = FindAnyObjectByType<GameManager>();
        pm.pointCount = 0;
    }

    void Update()
    {
        if (!gameManager.isGameActive) return;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
        
        if(collision.gameObject.CompareTag("Backwall"))
        {
            gameManager.GameOver();
        }
    }

    void FixedUpdate()
    {
        if (!gameManager.isGameActive) return;

        Vector3 moveVelocity = transform.forward * verticalInput * speed;

        Vector3 velocity = playerRb.linearVelocity;
        velocity.x = moveVelocity.x;
        velocity.z = moveVelocity.z;
        playerRb.linearVelocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            pm.pointCount++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("FishPoint"))
        {
            pm.pointCount++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
            animator.SetBool("Death", true);
            particlesmoke.Play();
        }
        if (other.gameObject.CompareTag("Dog"))
        {
            gameManager.GameOver();
            animator.SetBool("Death", true);
            particleFight.Play();
            gameManager.GameOver();
        }
    }

    public void StopAnimation()
    {
        animator.enabled = false;
        playerRb.linearVelocity = Vector3.zero;
        enabled = false;
    }
}