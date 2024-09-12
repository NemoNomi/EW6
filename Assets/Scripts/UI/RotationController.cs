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
                Debug.Log("Model with tag '" + modelTag + "' found: " + modelObject.name);
                buttonCanvas.gameObject.SetActive(true);
            }
        }
        else
        {
            if (!modelObject.activeInHierarchy)
            {
                Debug.Log("Model is deactivated or removed");
                buttonCanvas.gameObject.SetActive(false);
                modelObject = null; 
            }
        }
    }

    private void RotateLeft()
    {
        if (modelObject != null)
        {
            modelObject.transform.Rotate(0, rotationSpeed, 0);
            Debug.Log("Model is rotating left");
        }
        else
        {
            Debug.Log("No model assigned");
        }
    }

    private void RotateRight()
    {
        if (modelObject != null)
        {
            modelObject.transform.Rotate(0, -rotationSpeed, 0);
            Debug.Log("Model is rotating right");
        }
        else
        {
            Debug.Log("No model assigned");
        }
    }
}
