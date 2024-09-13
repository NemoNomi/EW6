using UnityEngine;
using UnityEngine.UI;

public class ExpandableMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public Button toggleButton;
    public float slideSpeed = 300f;

    private bool isMenuOpen = false;
    private Vector2 closedPosition; 
    private Vector2 openPosition; 

    void Start()
    {
        closedPosition = menuPanel.anchoredPosition;
        openPosition = new Vector2(closedPosition.x, closedPosition.y + (menuPanel.rect.height * 0.65f));

        toggleButton.onClick.AddListener(ToggleMenu);
    }

    void ToggleMenu()
    {
        StopAllCoroutines();
        if (isMenuOpen)
        {
            StartCoroutine(SlideMenu(closedPosition));
        }
        else
        {
            StartCoroutine(SlideMenu(openPosition));
        }
        isMenuOpen = !isMenuOpen;
    }

    System.Collections.IEnumerator SlideMenu(Vector2 targetPosition)
    {
        while (Vector2.Distance(menuPanel.anchoredPosition, targetPosition) > 0.1f)
        {
            menuPanel.anchoredPosition = Vector2.Lerp(menuPanel.anchoredPosition, targetPosition, Time.deltaTime * slideSpeed);
            yield return null;
        }
        menuPanel.anchoredPosition = targetPosition;
    }
}
