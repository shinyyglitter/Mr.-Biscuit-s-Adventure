using UnityEngine;

public class RowSpawnManager : MonoBehaviour
{ 
    public GameObject[] rowPrefabs; 
    private float spawnRangeX = 0f; 
    private float spawnPosZ = 30f; 
    private float startDelay = 0f; 
    private float spawnInterval = 1f; 
    public GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start() 
    { 
        
        
    } 

    public void StartSpawning()
    {
        InvokeRepeating("SpawnRandomRow", startDelay, spawnInterval); 
    }
    
    // Update is called once per frame 
    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.S)) { SpawnRandomRow(); } 
    }
         
    void SpawnRandomRow() 
    { 
        
            int rowIndex = Random.Range(0, rowPrefabs.Length); 
            Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); 
            Instantiate(rowPrefabs[rowIndex], spawnpos, rowPrefabs[rowIndex].transform.rotation); 
        
    } 
}
