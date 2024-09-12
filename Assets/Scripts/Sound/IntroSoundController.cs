using UnityEngine;

public class IntroSoundController : MonoBehaviour
{
    public string prefabTag = "modelObject"; 
    public AudioSource introAudioSource;      

    private GameObject spawnedPrefab;       
    private bool hasPlayedSound = false;    

    void Update()
    {
        if (!hasPlayedSound)
        {
            spawnedPrefab = GameObject.FindWithTag(prefabTag);

            if (spawnedPrefab != null)
            {
                if (introAudioSource != null)
                {
                    introAudioSource.Play();
                    hasPlayedSound = true;
                }
            }
        }
    }
}
