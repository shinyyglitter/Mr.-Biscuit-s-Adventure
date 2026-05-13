using UnityEngine;

public class FishSpawnManager : MonoBehaviour
{
    public GameObject[] fishPrefab; 
    public Transform fishSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Random.value < 0.7f)
        {
            Instantiate(fishPrefab[0], fishSpawnPoint.position, fishSpawnPoint.rotation, transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
