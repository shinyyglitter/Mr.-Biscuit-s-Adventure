using UnityEngine;

public class RowController : MonoBehaviour
{
    public static float speed = 2f;
    public static bool move = false;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!move) return;

        Vector3 movement = Vector3.back * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
