using UnityEngine;

public class DogController : MonoBehaviour
{
    private float speed = 4f;
    private GameManager gameManager;
    private Animator dogAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        dogAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive){
            dogAnimator.SetFloat("Speed", 0f);
            return;
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
        dogAnimator.SetFloat("Speed", speed);
    }
}
