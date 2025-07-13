using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string _description;

    public string description
    {
        get { return _description; }
    }
}
