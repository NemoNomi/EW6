using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoSoundController : MonoBehaviour
{
    public string prefabTag = "modelObject";
    public Button playSoundButton;
    private AudioSource audioSource;
    private bool isPrefabInstantiated = false;

    void Start()
    {
        StartCoroutine(CheckForInstantiatedPrefab());
    }

    IEnumerator CheckForInstantiatedPrefab()
    {
        while (!isPrefabInstantiated)
        {
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);

            if (spawnedPrefab != null && playSoundButton != null)
            {
                AudioSource[] audioSources = spawnedPrefab.GetComponentsInChildren<AudioSource>();

                if (audioSources.Length >= 2)
                {
                    audioSource = audioSources[1];

                    playSoundButton.onClick.AddListener(ToggleSpatialAudio);
                    isPrefabInstantiated = true;
                }
                else
                {
                    Debug.LogWarning("Weniger als 2 AudioSources im instanzierten Prefab gefunden.");
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void ToggleSpatialAudio()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("AudioSource fehlt.");
        }
    }
}
