using UnityEngine;
using System.Collections;

public class RowSpawnManager : MonoBehaviour
{ 
    public GameObject[] rowPrefabs; 
    public Transform lastRow;

    public int startRows =20;
    public float rowSpacing =2f;

    /*
    private float spawnRangeX = 0f; 
    private float spawnPosZ = 30f; 
    private float startDelay = 0f; 
    private float spawnInterval = 1f; 
    */
    
    public GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start() 
    { 
        for (int i = 0; i < startRows; i++)
            SpawnRandomRow();
    } 

    public void StartSpawning()
    {
        StartCoroutine(SpawnLoop());
        //InvokeRepeating("SpawnRandomRow", startDelay, spawnInterval); 
    }
    
    // Update is called once per frame 
    void Update() 
    { 
        //if (Input.GetKeyDown(KeyCode.S)) { SpawnRandomRow(); } 
    }

    IEnumerator SpawnLoop()
    {
        while (true){
            SpawnRandomRow();
            yield return new WaitForSeconds(1f);
        }
    }
         
    void SpawnRandomRow() 
    { 
        Vector3 pos = lastRow == null
            ? Vector3.zero
            : lastRow.position + Vector3.forward * rowSpacing;

        lastRow = Instantiate(rowPrefabs[Random.Range(0, rowPrefabs.Length)], pos, Quaternion.identity).transform;
        
            /*
            int rowIndex = Random.Range(0, rowPrefabs.Length); 
            Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); 
            Instantiate(rowPrefabs[rowIndex], spawnpos, rowPrefabs[rowIndex].transform.rotation); 
            */
    } 
}
