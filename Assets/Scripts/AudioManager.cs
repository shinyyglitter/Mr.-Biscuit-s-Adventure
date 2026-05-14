using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource ambientSource;

    [Header("Audio Clips")]
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

        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        if(!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
        }

        Load();
        ShowSliders();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayAmbient(AudioClip clip)
    {
        ambientSource.PlayOneShot(clip);
    }

    public void ChangeMusicVolume()
    {
        musicSource.volume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void ChangeSfxVolume()
    {
        sfxSource.volume = sfxSlider.value;
        ambientSource.volume = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }

    public void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;
        ambientSource.volume = sfxSlider.value;
    }

    public void ShowSliders()
    {
        musicSlider.gameObject.SetActive(true);
        sfxSlider.gameObject.SetActive(true);
    }

    public void HideSliders()
    {
        musicSlider.gameObject.SetActive(false);
        sfxSlider.gameObject.SetActive(false);
    }

}
