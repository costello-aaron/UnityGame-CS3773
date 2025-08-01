using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Interactable : MonoBehaviour
{
    [SerializeField][TextArea(3,10)] private string _description;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ParticleSystem _particleSystem;

    public void OnInteract()
    {
        UIManager uiManager = UIManager.GetInstance();
        uiManager.ShowPanel(name, description, icon);
        _particleSystem.Stop();
    }

    public string description
    {
        get { return _description; }
    }
    new public string name
    {
        get { return _name; }
    }
    public Sprite icon
    {
        get { return _icon; }
    }
}
