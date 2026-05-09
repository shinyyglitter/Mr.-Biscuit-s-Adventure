using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Transform carSpawnPoint;
    private float minInterval = 2f;
    private float maxInterval = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        SpawnRandomCar();
    } 

    // Update is called once per frame
    void Update() 
    { 

    }
         
    void SpawnRandomCar() 
    { 
        int randomIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[randomIndex],carSpawnPoint.position,carSpawnPoint.rotation,transform);
        float nextInterval = Random.Range(minInterval, maxInterval);
        Invoke(nameof(SpawnRandomCar), nextInterval);
        
    } 
}
