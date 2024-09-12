using UnityEngine;

public class PlaySoundOnPrefabSpawn : MonoBehaviour
{
    public string prefabTag = "modelObject";
    public AudioSource audioSource;
    public AudioClip spawnSound;

    private GameObject spawnedPrefab;
    private bool hasPlayedSound = false;

    void Update()
    {
        if (!hasPlayedSound)
        {
            spawnedPrefab = GameObject.FindWithTag(prefabTag);

            if (spawnedPrefab != null)
            {
                if (audioSource != null && spawnSound != null)
                {
                    audioSource.PlayOneShot(spawnSound);
                    hasPlayedSound = true;
                }
            }
        }
    }
}
