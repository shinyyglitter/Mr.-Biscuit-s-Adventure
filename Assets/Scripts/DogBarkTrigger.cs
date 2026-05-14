using UnityEngine;

public class DogBarkTrigger : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 100f;
    public float barkCooldown = 1.5f;

    private AudioSource dogAudio;
    private GameManager gameManager;
    private float nextBarkTime = 0f;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        player = FindAnyObjectByType<PlayerController>().transform;
        dogAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameManager.isGameActive) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance && Time.time >= nextBarkTime)
        {
            dogAudio.Play();
            nextBarkTime = Time.time + barkCooldown;
        }
    }
}
    

