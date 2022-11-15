using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    
    [Range(0f, 1.2f)]
    public float volume = 0.7f;
    [Range(0.3f, 1.3f)]
    public float pitch = 1f;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;

}
