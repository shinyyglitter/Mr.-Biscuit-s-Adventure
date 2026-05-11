using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs; 
    
    private float minInterval = 1f;
    private float maxInterval = 3f;
    public Transform carSpawnPoint;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        gameManager = FindAnyObjectByType<GameManager>(); 

        float randomStartDelay = Random.Range(minInterval, maxInterval);
        Invoke(nameof(SpawnRandomCar), randomStartDelay);
    } 

    // Update is called once per frame
    void Update() 
    { 

    }
         
    void SpawnRandomCar() 
    {
        int randomIndex = Random.Range(0, carPrefabs.Length);
        Instantiate(carPrefabs[randomIndex],carSpawnPoint.position,carSpawnPoint.rotation,transform);
        
        if (gameManager.isGameActive){
        float nextInterval = Random.Range(minInterval, maxInterval);
        Invoke(nameof(SpawnRandomCar), nextInterval);
        } 
    } 
}
