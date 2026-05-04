using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float bottomBound = -10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        if (transform.position.z < bottomBound || Mathf.Abs(x) > 25f) 
        {
            Destroy(gameObject);
        }
    }
}
