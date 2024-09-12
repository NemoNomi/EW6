using UnityEngine;
using UnityEngine.UI;

public class InfoSoundController : MonoBehaviour
{
    public Button playSoundButton; 
    public AudioSource audioSource;

    void Start()
    {
        if (playSoundButton != null)
        {
            playSoundButton.onClick.AddListener(PlaySpatialAudio);
        }
    }

    void PlaySpatialAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play(); 
        }
        else
        {
            Debug.LogWarning("AudioSource fehlt.");
        }
    }
}
