using UnityEngine;

[System.Serializable]
public class Sound
{
    public string nameSound;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource audioSource;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 2f)]
    public float pitch;

    public bool loop;
}
