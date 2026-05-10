using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs; 
    
    private float minInterval = 2f;
    private float maxInterval = 5f;
    public Transform carSpawnPoint;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        SpawnRandomCar();
    } 

    public void StartSpawning()

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

        gameManager = FindAnyObjectByType<GameManager>();
        
        if (gameManager.isGameActive){
        float nextInterval = Random.Range(minInterval, maxInterval);
        Invoke(nameof(SpawnRandomCar), nextInterval);
        } 
    } 
}
