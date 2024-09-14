using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour
{
    public string modelTag = "modelObject";  
    public Button actionButton;
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

                AudioSource[] audioSources = meshObject.GetComponentsInChildren<AudioSource>();
                if (audioSources.Length >= 3)
                {
                    animationAudioSource = audioSources[2]; 

                    if (actionButton.gameObject.activeInHierarchy)
                    {
                        actionButton.onClick.AddListener(PlayAction);
                        isPrefabInstantiated = true;
                    }
                }
                else
                {
                    Debug.LogWarning("Nicht genügend AudioSources auf dem Prefab gefunden.");
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
                StartCoroutine(PlayAnimationSoundWithDelay(soundDelay));
            }
        }
        else
        {
            Debug.LogWarning("Animator nicht gefunden.");
        }

        StartCoroutine(ResetClickCooldown());
    }

    IEnumerator PlayAnimationSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animationAudioSource.Play(); 
    }

    IEnumerator ResetClickCooldown()
    {
        yield return new WaitForSeconds(clickCooldown);
        canClick = true;
    }
}
