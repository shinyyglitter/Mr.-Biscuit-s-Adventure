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
        if(pointManager.pointCount >= 350)
    {
        RowController.speed = 5f;
    } else if(pointManager.pointCount >= 200)
    {
        RowController.speed = 4.5f;
    }else if(pointManager.pointCount >= 140)
    {
        RowController.speed = 4f;
    } else if(pointManager.pointCount >= 90)
    {
        RowController.speed = 3.5f;
    }else if(pointManager.pointCount >= 60)
    {
        RowController.speed = 3f;
    } else if(pointManager.pointCount >= 40)
    {
        RowController.speed = 2.5f;
    }else if(pointManager.pointCount >= 20)
    {
        RowController.speed = 2f;
    }else if(pointManager.pointCount >= 10)
    {
        RowController.speed = 1.5f;
    }
    }
}
