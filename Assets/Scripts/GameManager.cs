using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    
    public Image gameOverText;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI finalScoreText;
    public Image controllerI;
    public Image controllerII;
    public Image logoImage;
    public Image restartButton;
    public Image startButton;
    public Image bgOverlayI;
    public Image bgOverlayII;
    public Image scoreBox;
    public PointManager pointManager;
    public RowSpawnManager rowSpawnManager;
    public Animator animator;
    public PlayerController playerController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        bgOverlayII.gameObject.SetActive(false);
        scoreBox.gameObject.SetActive(false);
        playerController = FindAnyObjectByType<PlayerController>();
    }
    public void StartGame()
    {
        isGameActive = true;
        pointManager.pointCount = 0;
        scoreBox.gameObject.SetActive(true);
        pointText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        logoImage.gameObject.SetActive(false);
        controllerI.gameObject.SetActive(false);
        controllerII.gameObject.SetActive(false);
        bgOverlayI.gameObject.SetActive(false);
        RowController.speed = 2f;
        
        RowController.move = true;
        rowSpawnManager.StartSpawning();
    }

    public void GameOver()
    {
        isGameActive = false;
        RowController.move = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        pointText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "SCORE: " + pointManager.pointCount;
        bgOverlayII.gameObject.SetActive(true);
        scoreBox.gameObject.SetActive(false);
            
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
