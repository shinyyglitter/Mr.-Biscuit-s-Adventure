using UnityEngine;
using System.Collections;

public class RowSpawnManager : MonoBehaviour
{ 
    public GameObject[] rowPrefabs;
    public GameObject startPrefab;
    public Transform lastRow;
    private GameObject lastSpawnedPrefab;
    public int startRows = 20;
    public float rowSpacing = 2f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start() 
    { 
        for (int i = 0; i < startRows; i++)
        {
            if (i == 3)
            {
                SpawnRandomRow(startPrefab);
            }
            else
            {
                NoRepeatingRows();
            }
        }
            
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
        while (true)
        {
            NoRepeatingRows();
            yield return new WaitForSeconds(1f);
        }
    }

    void NoRepeatingRows()
    {
        GameObject selectedPrefab;
        
        do
        {
            selectedPrefab = rowPrefabs[Random.Range(0, rowPrefabs.Length)];
        }
        while (selectedPrefab == lastSpawnedPrefab && rowPrefabs.Length > 1);

        SpawnRandomRow(selectedPrefab);
            
    }
         
    void SpawnRandomRow(GameObject prefab) 
    { 
        Vector3 pos = lastRow == null
            ? Vector3.zero
            : lastRow.position + Vector3.forward * rowSpacing;

        lastRow = Instantiate(prefab, pos, Quaternion.identity).transform;
        lastSpawnedPrefab = prefab;
    } 
}
