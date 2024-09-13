using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour
{
    public string modelTag = "modelObject";  
    public Button actionButton;
    public AudioSource actionAudioSource;
    public AudioClip actionSound;
    private AudioSource animationAudioSource;
    public float soundDelay = 0.5f;
    public float clickCooldown = 1f;

    private Animator characterAnimator;  
    private bool isPrefabInstantiated = false;
    private bool canClick = true;

    void Start()
    {
        StartCoroutine(CheckForInstantiatedPrefab());
    }

    IEnumerator CheckForInstantiatedPrefab()
    {
        while (!isPrefabInstantiated)
        {
            GameObject meshObject = GameObject.FindWithTag(modelTag);

            if (meshObject != null)
            {
                characterAnimator = meshObject.GetComponentInParent<Animator>();

                if (characterAnimator != null && actionButton.gameObject.activeInHierarchy)
                {
                    AudioSource[] audioSources = meshObject.GetComponentsInChildren<AudioSource>();

                    if (audioSources.Length >= 3)
                    {
                        animationAudioSource = audioSources[2];

                        actionButton.onClick.AddListener(PlayAction);
                        isPrefabInstantiated = true;
                    }
                    else
                    {
                        Debug.LogWarning("Weniger als 3 AudioSources im instanzierten Prefab gefunden.");
                    }
                }
                else
                {
                    Debug.LogWarning("Animator oder Action Button konnte nicht gefunden werden.");
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void PlayAction()
    {
        if (!canClick) return;

        canClick = false;

        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger("DoAction");

            if (animationAudioSource != null)
            {
                animationAudioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("Animator nicht gefunden oder nicht zugewiesen.");
        }

        if (actionAudioSource != null && actionSound != null)
        {
            StartCoroutine(PlayActionSoundWithDelay(soundDelay));
        }

        StartCoroutine(ResetClickCooldown());
    }

    IEnumerator PlayActionSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        actionAudioSource.PlayOneShot(actionSound);
    }

    IEnumerator ResetClickCooldown()
    {
        yield return new WaitForSeconds(clickCooldown);
        canClick = true;
    }
}
