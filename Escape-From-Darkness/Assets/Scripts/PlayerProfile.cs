using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public InputField textBox;

    public void ClickSaveButton()
    {
        PlayerPrefs.SetString("playerName", textBox.text);
    }
}
