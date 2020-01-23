using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public GameObject exitPanel;

    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Level1");
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
    }
    
    public void OnClickExit()
    {
        exitPanel.SetActive(true);
    }

    public void OnClikExitPanel(int button)
    {
        if (button == 0)
        {
            SceneManager.LoadScene("Menu");
            FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");

        }
        else if (button == 1)
        {
            Application.Quit();
            FindObjectOfType<AudioManager>().PlayMusic("ClikMenu");
        }
    }
}
