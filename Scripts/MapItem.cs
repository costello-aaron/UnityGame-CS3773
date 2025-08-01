using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MapItem : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private bool visited;
    [SerializeField] private GameObject button;
    [SerializeField] private string label;
    [SerializeField] private Sprite icon;
    [TextArea(3, 10)] public string description;

    private void Start()
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = label;
        visited = PlayerPrefs.GetInt(sceneIndex.ToString(), 0) == 1; // Load visited state from PlayerPrefs
    }
    public void OnMouseEnter()
    {
        button.SetActive(true); 
    }

    public void OnMouseExit()
    {
        button.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager sceneManager = FindFirstObjectByType<SceneManager>();

        if (sceneManager != null)
        {
            sceneManager.LoadScene(sceneIndex);
        }

        else
        {
            Debug.LogError("No SceneManager detected!");
        }
    }

    public void DisplayInfo()
    {
        UIManager.GetInstance().ShowPanel(label, description, icon);
        Button button = GameObject.Find("Visit").GetComponent<Button>();
        Debug.Log(button);
        button.onClick.RemoveAllListeners(); // Clear previous listeners to avoid multiple calls
        button.onClick.AddListener(() => ChangeScene());
    }
}