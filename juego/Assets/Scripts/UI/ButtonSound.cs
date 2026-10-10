using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private SoundManager soundManager;
    public int audioID; //Id de la pista de audio que queramos reproducir (1 en este caso)

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void ExecuteSound()
    {
        var listAudios = soundManager.GetComponents<AudioSource>();
        listAudios[audioID].Play();
    }
}
