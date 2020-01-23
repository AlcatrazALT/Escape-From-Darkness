using UnityEngine;
using UnityEngine.UI;

public class PlayerNameText : MonoBehaviour
{
    public Text playerNameBox;

    void Start()
    {
        playerNameBox.text = PlayerPrefs.GetString("playerName");
    }

}
