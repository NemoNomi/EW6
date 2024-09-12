using UnityEngine;

public class IntroToggle : MonoBehaviour
{
    public Canvas infoCanvas;
    public GameObject prefab;

    private bool prefabIsActive = false;

    void Start()
    {
        infoCanvas.gameObject.SetActive(true);
    }

    void Update()
    {
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
        return prefab != null && prefab.activeInHierarchy;
    }
}
