using UnityEngine;

public class SceneManager : MonoBehaviour
{
    
    public void LoadScene(int sceneIndex)
    {
        ProgressTracker tracker = FindFirstObjectByType<ProgressTracker>();

        if (tracker != null)
        {
            tracker.UpdateProgress(sceneIndex);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }
    }

    public void ReturnToMap()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
}