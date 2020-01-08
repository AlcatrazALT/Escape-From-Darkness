using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutotialPanel;
    public GameObject exitPanel;

    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Level1");
        GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().clik);
    }

    public void OnClickTutorial()
    {
        tutotialPanel.SetActive(true);
        GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().clik);
    }
    public void OnClikTutorialBackButton()
    {
        SceneManager.LoadScene("Menu");
        GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().clik);
    }

    public void OnClickExit()
    {
        exitPanel.SetActive(true);
        GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().clik);
    }

    public void OnClikExitPanel(int button)
    {
        if(button == 0)
        {
            SceneManager.LoadScene("Menu");
            GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().clik);
        }
        else if(button == 1)
        {
            Application.Quit();
            GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().clik);
        }
    }
}
