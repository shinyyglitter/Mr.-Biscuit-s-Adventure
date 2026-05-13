using UnityEngine;

public class ParentPlayer : MonoBehaviour
{
    private Vector3 lastPosition;
    private Vector3 platformDelta;

    void Awake()
    {
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        platformDelta = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null && platformDelta != Vector3.zero)
            {
                playerRb.MovePosition(playerRb.position + platformDelta);
            }
        }
    }
}