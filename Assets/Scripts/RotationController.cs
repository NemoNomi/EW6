using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour
{
public Button buttonRotateLeft;  
    public Button buttonRotateRight;
    public string modelTag = "modelObject";  
    private GameObject modelObject;  
    public Canvas buttonCanvas;      

    public float rotationSpeed = 15f;

    private void Start()
    {
        buttonCanvas.gameObject.SetActive(false);

        buttonRotateLeft.onClick.AddListener(RotateLeft);
        buttonRotateRight.onClick.AddListener(RotateRight);
    }

    private void Update()
    {
        if (modelObject == null)
        {
            modelObject = GameObject.FindWithTag(modelTag);

            if (modelObject != null)
            {
                Debug.Log("Modell mit Tag '" + modelTag + "' gefunden: " + modelObject.name);
                buttonCanvas.gameObject.SetActive(true); 
            }
        }
    }

    private void RotateLeft()
    {
        if (modelObject != null)
        {
            modelObject.transform.Rotate(0, rotationSpeed, 0);
            Debug.Log("Modell dreht sich nach links");
        }
        else
        {
            Debug.Log("Kein Modell zugewiesen");
        }
    }

    private void RotateRight()
    {
        if (modelObject != null)
        {
            modelObject.transform.Rotate(0, -rotationSpeed, 0);
            Debug.Log("Modell dreht sich nach rechts");
        }
        else
        {
            Debug.Log("Kein Modell zugewiesen");
        }
    }
}