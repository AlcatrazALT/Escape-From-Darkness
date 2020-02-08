using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelToLoad;
    public GameObject teleportPanel;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            SaveScore();
            teleportPanel.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            if(Input.GetKeyDown("w"))
            {
                SaveScore();
                Teleporting();
            }
        }
    }

    void Teleporting()
    {
        FindObjectOfType<AudioManager>().PlayMusic("Teleport");
        SceneManager.LoadScene(levelToLoad);
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            teleportPanel.SetActive(false);
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("Score", scoreManager.playerScore);
    }
}