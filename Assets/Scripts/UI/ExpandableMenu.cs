using UnityEngine;
using UnityEngine.UI;

public class ExpandableMenu : MonoBehaviour
{
    public RectTransform menuPanel;  // Das Panel, das die Buttons enthält
    public Button toggleButton;      // Der Button (Lasche), um das Menü ein- und auszuklappen
    public float slideSpeed = 300f;  // Die Geschwindigkeit, mit der das Menü nach oben/unten fährt

    private bool isMenuOpen = false; // Status des Menüs
    private Vector2 closedPosition;  // Position des Panels, wenn es geschlossen ist
    private Vector2 openPosition;    // Position des Panels, wenn es geöffnet ist

    void Start()
    {
        // Initiale Positionen speichern
        closedPosition = menuPanel.anchoredPosition;
        openPosition = new Vector2(closedPosition.x, closedPosition.y + menuPanel.rect.height);

        // Listener für den Button hinzufügen
        toggleButton.onClick.AddListener(ToggleMenu);
    }

    void ToggleMenu()
    {
        StopAllCoroutines();  // Stoppe andere Bewegungen des Panels
        if (isMenuOpen)
        {
            StartCoroutine(SlideMenu(closedPosition));  // Menü nach unten fahren
        }
        else
        {
            StartCoroutine(SlideMenu(openPosition));  // Menü nach oben fahren
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
        menuPanel.anchoredPosition = targetPosition;  // Endposition setzen
    }
}
