using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public Sound[] soundArr;
    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound theSound in soundArr)
        {
            theSound.audioSource = gameObject.AddComponent<AudioSource>();
            theSound.audioSource.clip = theSound.clip;
            theSound.audioSource.volume = theSound.volume;
            theSound.audioSource.pitch = theSound.pitch;
            theSound.audioSource.loop = theSound.loop;
        }
    }
    void Start()
    {
        PlayMusic("GameBackGroundMusic");
    }
    public void PlayMusic(string nameSound)
    {
        Sound theSound = Array.Find(soundArr, sound => sound.nameSound == nameSound);
        if (theSound == null)
        {
            Debug.LogWarning($"Sound {nameSound} not found");
            return;
        }
        theSound.audioSource.Play();
    }
}

