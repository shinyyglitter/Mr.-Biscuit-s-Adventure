using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
        public AudioClip background;
        public AudioClip jump;
        public AudioClip point;
        public AudioClip dog;
        public AudioClip cat;
        public AudioClip carCrash;
        public AudioClip buttonClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
