using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Transform carSpawnPoint;
    //private float spawnRangeX = 0f; 
    //private float spawnPosZ = 10f; 
    //private float startDelay = 0f; 
    //private float spawnInterval = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        SpawnRandomCar();
        //InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval); 
    } 

    // Update is called once per frame
    void Update() 
    { 
        //if (Input.GetKeyDown(KeyCode.S)) { SpawnRandomCar(); } 
    }
         
    void SpawnRandomCar() 
    { 
        int randomIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[randomIndex],carSpawnPoint.position,carSpawnPoint.rotation,transform);
        
    } 
}
