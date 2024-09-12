using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    public float volume = 0.3f; 

    void Start()
    {
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.volume = volume;
            audioSource.loop = true;     
            audioSource.Play();         
        }
        else
        {
            Debug.LogWarning("AudioSource oder AudioClip nicht zugewiesen!");
        }
    }
}
