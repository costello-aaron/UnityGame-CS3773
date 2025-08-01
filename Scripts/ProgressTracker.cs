using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public bool[] visitedScenes;

    private void Awake()
    {
        if (visitedScenes == null || visitedScenes.Length < 3)
        {
            visitedScenes = new bool[3];
        }
    }

    public void UpdateProgress(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < visitedScenes.Length)
        {
            visitedScenes[sceneIndex] = true;
            Debug.Log($"Scene {sceneIndex} marked as visited.");
        }
    }
}
