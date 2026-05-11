using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public PointManager pointManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(pointManager.pointCount >= 120)
    {
        Debug.Log("Increasing speed");
        RowController.speed = 5f;
    } else if(pointManager.pointCount >= 80)
    {
        RowController.speed = 4f;
        Debug.Log("Increasing speed");
    } else if(pointManager.pointCount >= 40)
    {
        RowController.speed = 3f;
        Debug.Log("Increasing speed");
    }
    }
}
