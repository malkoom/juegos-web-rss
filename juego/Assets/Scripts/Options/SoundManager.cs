using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioMixer musicMixer;
    public AudioMixer soundMixer;

    public AudioSource music;
    public AudioSource sound;

    public float mVolume;
    public float sVolume;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        music = GetComponent<AudioSource>();
        sound = GetComponent<AudioSource>();
    }

    private void LoadVolume()
    {
        float musicVolume = PlayerPrefs.HasKey("Music") ? PlayerPrefs.GetFloat("Music") : 1f; //Si existe una preferencia para el audio, se tomará el volumen de "Music", sino será el máximo
        float soundVolume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1f; //Si existe una preferencia para el audio, se tomará el volumen de "Sound", sino será el máximo

        musicMixer.SetFloat("Volume", Mathf.Log10(musicVolume) * 20);
        soundMixer.SetFloat("Volume", Mathf.Log10(soundVolume) * 20);
    }

    public void SetMusic(float vol)
    {
        vol = Mathf.Clamp(vol, 0.001f, 1f); //Para evitar que el volumen aumente al llegar a 0 el slider
        musicMixer.SetFloat("Volume", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("Music", vol);
        PlayerPrefs.Save();
    }
    
    public void SetSound(float vol)
    {
        vol = Mathf.Clamp(vol, 0.001f, 1f); //Para evitar que el volumen aumente al llegar a 0 el slider
        soundMixer.SetFloat("Volume", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("Sound", vol);
        PlayerPrefs.Save();
    }

    public void SaveMusic(float vol)
    {
        PlayerPrefs.GetFloat("Music", vol);
    }
    public void SaveSound(float vol)
    {
        PlayerPrefs.GetFloat("Sound", vol);
    }

    void Start()
    {
        LoadVolume();
        music.Play();
    }

    void Update()
    {
        
    }
}
