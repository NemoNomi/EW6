using UnityEngine;
using UnityEngine.UI;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator characterAnimator;
    public Button actionButton;
    public AudioSource audioSource;
    public AudioClip actionSound;

    void Start()
    {
        actionButton.onClick.AddListener(PlayAction);
    }
    void PlayAction()
    {
        characterAnimator.SetTrigger("DoAction");
        
        if (audioSource != null && actionSound != null)
        {
            audioSource.PlayOneShot(actionSound);
        }
    }
}
