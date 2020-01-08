using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    Dictionary<string, Dictionary<string, int>> playerScores;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Init()
    {
        if(playerScores != null)
        {
            return;
        }
        playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetScore(string userName, string scoreType)
    {
        Init();
        if(playerScores.ContainsKey(userName) == false)
        {
            // no score record at all for this player
            return 0;
        }

        if(playerScores[userName].ContainsKey(scoreType) == false)
        {
            return 0;
        }
        return playerScores[userName][scoreType];
    }

    public void SetScore(string userName, string scoreType, int value)
    {
        Init();
        if (playerScores.ContainsKey(userName) == false)
        {
            playerScores[userName] = new Dictionary<string, int>();
        }
        playerScores[userName][scoreType] = value;
    }

    public void ChangeScore(string userName, string scoreType, int amount)
    {
        Init();
        int currentScore = GetScore(userName, scoreType);
        SetScore(userName, scoreType, currentScore + amount);
    }
}
