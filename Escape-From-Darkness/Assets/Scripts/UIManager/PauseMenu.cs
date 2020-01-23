using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuPanel;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        scoreManager.ResertScore();
    }

    public void LoadMenu()
    {
        Debug.Log("Load");
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        Debug.Log("Quit");
        Application.Quit();
    }
}
