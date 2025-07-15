using UnityEngine;
using TMPro;

public class MapItem : MonoBehaviour
{
    public int SceneIndex;
    public string Tooltip;
    public bool Visted;

    public TextMeshProUGUI infoText;

    public void ChangeScene()
    {
        SceneManager sceneManager = FindFirstObjectByType<SceneManager>();

        if (sceneManager != null)
        {
            sceneManager.LoadScene(SceneIndex);
        }

        else
        {
            Debug.LogError("No SceneManager detected!");
        }
    }

    public void DisplayInfo()
    {
        if (infoText != null)
        {
            infoText.text = Tooltip;
        }

        else
        {
            Debug.Log("No UI Text assigned");
        }
    }
}