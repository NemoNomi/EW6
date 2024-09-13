using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonSoundController : MonoBehaviour
{
    public string prefabTag = "modelObject";
    public List<Button> buttons = new List<Button>();
    private AudioSource buttonAudioSource;
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

            if (spawnedPrefab != null)
            {
                AudioSource[] audioSources = spawnedPrefab.GetComponentsInChildren<AudioSource>();

                if (audioSources.Length >= 4)
                {
                    buttonAudioSource = audioSources[3];

                    if (buttons.Count > 0 && buttonAudioSource != null)
                    {
                        foreach (Button button in buttons)
                        {
                            button.onClick.AddListener(PlayClickSound);
                        }
                        isPrefabInstantiated = true;
                    }
                    else
                    {
                        Debug.LogWarning("Es wurden keine Buttons zugewiesen oder die AudioSource fehlt.");
                    }
                }
                else
                {
                    Debug.LogWarning("Weniger als 4 AudioSources im instanzierten Prefab gefunden.");
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void PlayClickSound()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Die Button AudioSource fehlt.");
        }
    }
}
