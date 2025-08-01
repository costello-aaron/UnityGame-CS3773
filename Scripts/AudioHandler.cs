using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    public AudioMixerGroup master;
    public AudioMixerGroup effects;
    public AudioMixerGroup music;
    public AudioClip ambient_city, ambient_desert, ambient_park, game_music, interaction_noise;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
