using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button startButton;
    public PointManager pointManager;
    public RowSpawnManager rowSpawnManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        isGameActive = true;
        pointManager.pointCount = 0;

        startButton.gameObject.SetActive(false);
        
        RowController.move = true;
        rowSpawnManager.StartSpawning();
    }

    public void GameOver()
    {
        isGameActive = false;
        RowController.move = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
            
    }
    public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
