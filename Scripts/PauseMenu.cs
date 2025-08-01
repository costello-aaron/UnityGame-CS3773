using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Continue();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        Button firstButton = PausePanel.GetComponentInChildren<Button>();
        if (firstButton != null)
            EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
    }

    public void Continue()
    {
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ReturnToMap()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
