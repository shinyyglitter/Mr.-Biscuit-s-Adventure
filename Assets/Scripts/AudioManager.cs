using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource AmbientSource;

    [Header("Audio Clips")]
        public AudioClip background;
        public AudioClip jump;
        public AudioClip point;
        public AudioClip dog;
        public AudioClip cat;
        public AudioClip carCrash;
        public AudioClip buttonClick;

        public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayAmbient(AudioClip clip)
    {
        if (!gameManager.isGameActive) return;
        AmbientSource.PlayOneShot(clip);
    }
    public void StopAmbient()
    {
        AmbientSource.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
