using UnityEngine;

public class ParentPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void LateUpdate()
    {
        lastPosition = transform.position;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 platformDelta = transform.position - lastPosition;

            playerRb.MovePosition(playerRb.position + platformDelta);
        }
    }
}
