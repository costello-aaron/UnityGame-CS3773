using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int currentSceneIndex;
    
    public void LoadScene(int sceneIndex)
    {
        currentSceneIndex = sceneIndex;

        ProgressTracker tracker = FindFirstObjectByType<ProgressTracker>();

        if (tracker != null && currentSceneIndex > 0)
        {
            tracker.UpdateProgress(sceneIndex);
        }
    }

    public void ReturnToMap()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}