using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs; 
    private float spawnRangeX = 0f; 
    private float spawnPosZ = 10f; 
    private float startDelay = 0f; 
    private float spawnInterval = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval); 
    } 

    // Update is called once per frame
    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.S)) { SpawnRandomCar(); } 
    }
         
    void SpawnRandomCar() 
    { 
        int carIndex = Random.Range(0, carPrefabs.Length); 
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); 
        Instantiate(carPrefabs[carIndex], spawnpos, carPrefabs[carIndex].transform.rotation); 
    } 
}
