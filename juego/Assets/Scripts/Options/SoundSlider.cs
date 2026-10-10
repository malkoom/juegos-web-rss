using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public Slider music;
    public Slider sound;

    private void Start()
    {
        SetSliders();

        music.onValueChanged.AddListener((volume) => ChangeMusicVolume(volume));
        sound.onValueChanged.AddListener((volume) => ChangeSoundVolume(volume));
    }

    private void SetSliders()
    {
        float musicVolume = PlayerPrefs.HasKey("Music") ? PlayerPrefs.GetFloat("Music") : 1f; //Si existe una preferencia para el audio, se tomará el volumen de "Music", sino será el máximo
        float soundVolume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1f; //Si existe una preferencia para el audio, se tomará el volumen de "Sound", sino será el máximo
    
        music.value = musicVolume;
        sound.value = soundVolume;
    }

    public void ChangeMusicVolume(float volume)
    {
        SoundManager.instance.SetMusic(volume);
    }

    public void ChangeSoundVolume(float volume)
    {
        SoundManager.instance.SetSound(volume);
    }


}
