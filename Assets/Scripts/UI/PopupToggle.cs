using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PopupToggle : MonoBehaviour
{
    public string modelTag = "modelObject";  
    public Canvas toggleButtonCanvas;        
    public List<Button> toggleButtons = new List<Button>();  
    public List<GameObject> infoPopupCanvases = new List<GameObject>();  

    private GameObject modelObject;  
    private bool prefabIsInstantiated = false;  

    void Start()
    {
        toggleButtonCanvas.gameObject.SetActive(false);

        if (toggleButtons.Count != infoPopupCanvases.Count)
        {
            Debug.LogError("Die Anzahl der Buttons und Canvases muss gleich sein.");
            return;
        }

        for (int i = 0; i < toggleButtons.Count; i++)
        {
            int index = i;
            toggleButtons[i].onClick.AddListener(() => TogglePopup(index));
            infoPopupCanvases[i].SetActive(false);
        }
    }

    void Update()
    {
        modelObject = GameObject.FindWithTag(modelTag);

        if (modelObject != null && !prefabIsInstantiated)
        {
            toggleButtonCanvas.gameObject.SetActive(true);
            prefabIsInstantiated = true;
        }
        else if (modelObject == null && prefabIsInstantiated)
        {
            toggleButtonCanvas.gameObject.SetActive(false);
            prefabIsInstantiated = false;
        }
    }

    void TogglePopup(int index)
    {
        if (prefabIsInstantiated && modelObject != null)
        {
            bool isActive = infoPopupCanvases[index].activeSelf;
            infoPopupCanvases[index].SetActive(!isActive);
        }
        else
        {
            Debug.LogWarning("Das Modell ist noch nicht in der Szene aktiv oder wurde entfernt.");
        }
    }
}
