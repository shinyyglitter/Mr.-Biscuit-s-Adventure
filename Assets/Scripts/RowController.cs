using UnityEngine;

public class RowController : MonoBehaviour
{

    private float speed = 2f;
    public static bool move = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!move) return;
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
