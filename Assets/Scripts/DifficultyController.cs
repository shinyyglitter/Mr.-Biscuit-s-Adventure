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
        if(pointManager.pointCount >= 105)
    {
        RowController.speed = 5f;
    } else if(pointManager.pointCount >= 90)
    {
        RowController.speed = 4.5f;
    }else if(pointManager.pointCount >= 75)
    {
        RowController.speed = 4f;
    } else if(pointManager.pointCount >= 60)
    {
        RowController.speed = 3.5f;
    }else if(pointManager.pointCount >= 45)
    {
        RowController.speed = 3f;
    } else if(pointManager.pointCount >= 30)
    {
        RowController.speed = 2.5f;
    }else if(pointManager.pointCount >= 15)
    {
        RowController.speed = 2f;
    }else if(pointManager.pointCount >= 5)
    {
        RowController.speed = 1.5f;
    }
    }
}
