using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField] private GameObject[] trackerUI = new GameObject[3];
    public void Start()
    {
        // Initialize the progress tracker UI based on saved PlayerPrefs
        for (int i = 2; i < 5; i++)//+2 since the first scene is the main menu and the second is the map
        {
            if (PlayerPrefs.GetInt(i.ToString(), 0) == 1) 
            {
                trackerUI[i-2].SetActive(true);
            }
            else
            {
                trackerUI[i-2].SetActive(false);
            }
        }
    }

    public void UpdateProgress(int sceneIndex)
    {
        trackerUI[sceneIndex - 2].SetActive(true);//-2 since the first scene is the main menu and the second is the map
        PlayerPrefs.SetInt(sceneIndex.ToString(), 1);
    }
}
