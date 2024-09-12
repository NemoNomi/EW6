using UnityEngine;

public class IntroToggle : MonoBehaviour
{
    public Canvas infoCanvas;
    public string modelTag = "modelObject";

    private GameObject modelObject;
    private bool prefabIsActive = false;

    void Start()
    {
        infoCanvas.gameObject.SetActive(true);
    }

    void Update()
    {
        modelObject = GameObject.FindWithTag(modelTag);

        if (IsPrefabActive() && !prefabIsActive)
        {
            infoCanvas.gameObject.SetActive(false);
            prefabIsActive = true;
        }
        else if (!IsPrefabActive() && prefabIsActive)
        {
            infoCanvas.gameObject.SetActive(true);
            prefabIsActive = false;
        }
    }

    bool IsPrefabActive()
    {
        return modelObject != null && modelObject.activeInHierarchy;
    }
}
