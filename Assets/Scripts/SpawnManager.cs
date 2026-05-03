using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    public GameObject[] rowPrefabs; 
    private float spawnRangeX = 0f; 
    private float spawnPosZ = 15f; 
    private float startDelay = 0f; 
    private float spawnInterval = 1f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created 

    void Start() 
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
