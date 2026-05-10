using UnityEngine;
using System.Collections;

public class RowSpawnManager : MonoBehaviour
{ 
    public GameObject[] rowPrefabs; 
    public Transform lastRow;
    public int startRows =20;
    public float rowSpacing =2f; 
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
    }
    
    // Update is called once per frame 
    void Update() 
    { 

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
    } 
}
