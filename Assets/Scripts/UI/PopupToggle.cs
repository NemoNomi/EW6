using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PopupToggle : MonoBehaviour
{
    public string modelTag = "modelObject";  
    public Canvas toggleButtonCanvas;        
    public List<Button> toggleButtons = new List<Button>();  
    private List<GameObject> infoPopupCanvases = new List<GameObject>();  

    private GameObject modelObject;  
    private bool prefabIsInstantiated = false;  

    void Start()
    {
        toggleButtonCanvas.gameObject.SetActive(false);

        if (toggleButtons.Count == 0)
        {
            Debug.LogError("Es müssen Toggler-Buttons zugewiesen werden.");
            return;
        }

        for (int i = 0; i < toggleButtons.Count; i++)
        {
            int index = i;
            toggleButtons[i].onClick.AddListener(() => TogglePopup(index));
        }
    }

    void Update()
    {
        modelObject = GameObject.FindWithTag(modelTag);

        if (modelObject != null && !prefabIsInstantiated)
        {
            FindCanvasesInModelObject();

            if (infoPopupCanvases.Count > 0)
            {
                Debug.Log("Model instanziert und Canvases gefunden.");
                toggleButtonCanvas.gameObject.SetActive(true);
                prefabIsInstantiated = true;
            }
        }
        else if (modelObject == null && prefabIsInstantiated)
        {
            Debug.Log("Model entfernt oder nicht vorhanden.");
            toggleButtonCanvas.gameObject.SetActive(false);
            prefabIsInstantiated = false;
        }
    }

    void FindCanvasesInModelObject()
    {
        infoPopupCanvases.Clear();

        Canvas[] prefabCanvases = modelObject.GetComponentsInChildren<Canvas>(true);

        foreach (Canvas canvas in prefabCanvases)
        {
            infoPopupCanvases.Add(canvas.gameObject);
            canvas.gameObject.SetActive(false);
        }

        if (infoPopupCanvases.Count < toggleButtons.Count)
        {
            Debug.LogWarning("Weniger Canvases gefunden als Toggler-Buttons vorhanden sind.");
        }
    }

    void TogglePopup(int index)
    {
        if (prefabIsInstantiated && modelObject != null && index < infoPopupCanvases.Count)
        {
            bool isActive = infoPopupCanvases[index].activeSelf;
            infoPopupCanvases[index].SetActive(!isActive);
            Debug.Log($"Canvas {infoPopupCanvases[index].name} wurde {(isActive ? "deaktiviert" : "aktiviert")}.");
        }
        else
        {
            Debug.LogWarning("Das Modell ist noch nicht in der Szene aktiv oder keine Canvas gefunden.");
        }
    }
}
