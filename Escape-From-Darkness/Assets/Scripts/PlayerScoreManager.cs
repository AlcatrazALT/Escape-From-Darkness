using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreManager : MonoBehaviour
{
    public static int playerScore;
    Text playerScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScoreText = GetComponent<Text>();
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore < 0)
        {
            playerScore = 0;
        }
        playerScoreText.text = "" + playerScore;
    }

    public static void AddPlayerPoint(int pointToAdd)
    {
        playerScore += pointToAdd;
    }

    public static void Resert()
    {
        playerScore = 0;
    }
}
