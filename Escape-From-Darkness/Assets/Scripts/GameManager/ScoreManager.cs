using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int scoreToAdd;
    public int playerScore;
    public int highScore = 0;

    public Text scoreText, highScoreText, gameOverScoreText;

    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            if((SceneManager.GetActiveScene().buildIndex + 0) == 0)
            {
                PlayerPrefs.DeleteKey("Score");
                playerScore = 0;
            }
            else
            {
                playerScore = PlayerPrefs.GetInt("Score");
            }
        }

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    void Update()
    {
        scoreText.text = playerScore.ToString();
    }

    public void AddScore()
    {
        playerScore += scoreToAdd;
        UpdateHighScore();
        scoreText.text = playerScore.ToString();
        gameOverScoreText.text = scoreText.text;
    }

    public void UpdateHighScore()
    {

        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(playerScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", playerScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
    }

    public void ResertScore()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        gameOverScoreText.text = playerScore.ToString();
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = highScore.ToString();
    }
}
