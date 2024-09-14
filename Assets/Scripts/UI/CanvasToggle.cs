using UnityEngine;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    public Button questionButton;
    public Canvas infoCanvas;
    public AudioSource audioSource; 

    void Start()
    {
        if (infoCanvas != null)
        {
            infoCanvas.gameObject.SetActive(false);
        }

        if (questionButton != null)
        {
            questionButton.onClick.AddListener(ToggleInfoCanvas);
        }
    }

    void ToggleInfoCanvas()
    {
        if (infoCanvas != null)
        {
            infoCanvas.gameObject.SetActive(!infoCanvas.gameObject.activeSelf);
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
