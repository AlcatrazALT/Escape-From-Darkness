using UnityEngine;

public class AudioBox : MonoBehaviour
{
    public AudioClip clik;
    public AudioClip playerJump;
    public AudioClip playerHurt;
    public AudioClip playerDead;
    public AudioClip playerShoot;
    public AudioClip enemyDead;
    public AudioClip coinPickUp;
    public AudioClip healthPickUp;
    public AudioClip levelLoader;

    private void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Audio").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AudioPlay(AudioClip theAudioClip)
    {
        GetComponent<AudioSource>().clip = theAudioClip;
        GetComponent<AudioSource>().Play();
    }
}

