using UnityEngine;

public class DogSpawnManager : MonoBehaviour
{
    public GameObject[] dogPrefab; 
    public Transform dogSpawnPoint;
    public GameManager gameManager;
    private float minInterval = 4f;
    private float maxInterval = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>(); 

        float randomStartDelay = Random.Range(minInterval, maxInterval);
        Invoke(nameof(SpawnDog), randomStartDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnDog() 
    {
        int randomIndex = Random.Range(0, dogPrefab.Length);
        Instantiate(dogPrefab[randomIndex],dogSpawnPoint.position,dogSpawnPoint.rotation,transform);
        
        if (gameManager.isGameActive){
        float nextInterval = Random.Range(minInterval, maxInterval);
        Invoke(nameof(SpawnDog), nextInterval);
        } 
    } 
}
