using UnityEngine;
using System.Collections;

public class IntroSoundController : MonoBehaviour
{
    public string prefabTag = "modelObject"; 
    private AudioSource introAudioSource;
    private bool hasPlayedSound = false;    

    void Start()
    {
        StartCoroutine(CheckForInstantiatedPrefab());
    }

    IEnumerator CheckForInstantiatedPrefab()
    {
        while (!hasPlayedSound)
        {
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);

            if (spawnedPrefab != null)
            {
                AudioSource[] audioSources = spawnedPrefab.GetComponentsInChildren<AudioSource>();

                if (audioSources.Length > 0)
                {
                    introAudioSource = audioSources[0];

                    if (introAudioSource != null)
                    {
                        introAudioSource.Play();
                        hasPlayedSound = true;
                    }
                }
                else
                {
                    Debug.LogWarning("Keine AudioSource im instanzierten Prefab gefunden.");
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
