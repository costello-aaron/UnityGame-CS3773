using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas; 
    [SerializeField] private TextMeshProUGUI eventText;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI panelTitle;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Image panelImage;
    public GameObject UIPause;

    private static UIManager instance;
    public bool gamePaused=false;
    public bool mutex = false; // Mutex to prevent multiple coroutines from running simultaneously

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gamePaused && mutex)// if the game is not paused and something is being displayed
            {
                HidePanel();
            }else
            {
                gamePaused = togglePause(gamePaused);
            }

            
        }
    }

    bool togglePause(bool val){
        if (mutex && !val) return false; //don't show multiple ui elements at once
        if (val == true)
        {
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked; // lock the cursor
            mutex = false;
            Debug.Log("UnPausing Game");
            UIPause.SetActive(false);
            Time.timeScale = 1;
            return false;
        }
        else
        {
            Cursor.visible = true; // Show the cursor when paused
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            mutex = true;
            Debug.Log("Pausing Game");
            UIPause.SetActive(true);
            Time.timeScale = 0;
            return true;
        }
    }

    public static UIManager GetInstance()
    {
        return instance;
    }

    public void DisplayEventText(string text)
    {
        if (eventText != null)
        {
            eventText.text = text;
        }
        else
        {
            Debug.LogWarning("Event Text is not assigned in the UIManager.");
        }
    }

    public void ShowPanel(string title, string text, Sprite img = null)
    {
        if (mutex) return; //don't show multiple UI elements at once
        mutex = true;
        if (panel != null)
        {
            panel.SetActive(true);
            panelTitle.text = title;
            panelText.text = text;
            if (img != null)
            {
                panelImage.sprite = img; // Set the image if provided
            }
            else
            {
                panelImage.gameObject.SetActive(false); // Hide the image if not provided
            }
        }
        else
        {
            Debug.LogWarning("Panel is not assigned in the UIManager.");
        }
    }

    private void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            panelTitle.text = "";
            panelText.text = "";
            panelImage.sprite = null;
            mutex = false;
        }
        else
        {
            Debug.LogWarning("Panel is not assigned in the UIManager.");
        }
    }
}
