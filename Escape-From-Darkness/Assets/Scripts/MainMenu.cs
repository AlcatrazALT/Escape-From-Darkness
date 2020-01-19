using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutotialPanel;
    public GameObject exitPanel;
    public GameObject inputPanel;
    public Text highScoreText;
    private ScoreManager scoreManager;

    void Start()
    {
        highScoreText.text = ($"{PlayerPrefs.GetString("playerName")} {PlayerPrefs.GetInt("HighScore")}");
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void OnClickStartGame()
    {
        inputPanel.SetActive(true);
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
    }

    public void OnClickResetHighScore()
    {
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        scoreManager.ClearHighScore();
    }

    public void OnClickTutorial()
    {
        tutotialPanel.SetActive(true);
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
    }

    public void OnClikGoToMenu()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
    }

    public void OnClickExit()
    {
        exitPanel.SetActive(true);
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
    }

    public void OnClikExitPanel(int button)
    {
        if(button == 0)
        {
            SceneManager.LoadScene("Menu");
            FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");

        }
        else if(button == 1)
        {
            Application.Quit();
            FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        }
    }

    public void OnClikInputFieldMenu()
    {
        inputPanel.SetActive(false);
        SceneManager.LoadScene("Level1");
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
    }
}
