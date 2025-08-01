using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas; 
    [SerializeField] private TextMeshProUGUI eventText;
    [SerializeField] private GameObject panel; 

    private static UIManager instance;
    bool mutex = false; // Mutex to prevent multiple coroutines from running simultaneously

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    public static UIManager GetInstance()
    {
        return instance;
    }

    public IEnumerator DisplayEventText(string text, int duration)
    {
        if (!mutex) mutex = true;
        else
        {
            Debug.LogWarning("Coroutine already running, skipping new event text display.");
            yield break; // Exit if a coroutine is already running
        }

        if (eventText != null)
        {
            eventText.text = text;
            eventText.gameObject.SetActive(true);
            yield return new WaitForSeconds(duration);
            eventText.gameObject.SetActive(false);
            eventText.text = ""; // Clear the text after displaying
            mutex = false;
        }
        else
        {
            Debug.LogWarning("Event Text is not assigned in the UIManager.");
        }
    }

    public void ShowPanel(string text, Image img = null)
    {
        if (panel != null)
        {
            panel.SetActive(true);

            //put text
            //check if image is not null, display it if so
        }
        else
        {
            Debug.LogWarning("Panel is not assigned in the UIManager.");
        }
    }
}
