using UnityEngine;
using UnityEngine.UI;

public class GameCleaner : MonoBehaviour
{
    public GameObject gameOverPanel;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player")
        {
            PlayerHealth playerFell = otherCollider.GetComponent<PlayerHealth>();
            playerFell.MakePlayerDead();
            //gameOverPanel.SetActive(true);
        }
        else
        {
            Destroy(otherCollider.gameObject);
        }
    }
}
