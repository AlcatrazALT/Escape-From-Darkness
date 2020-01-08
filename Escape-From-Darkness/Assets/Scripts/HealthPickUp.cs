using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float playerHealthAmount;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player")
        {
            PlayerHealth playerHealth = otherCollider.gameObject.GetComponent<PlayerHealth>();
            playerHealth.PlayerGetHealth(playerHealthAmount);
            GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().healthPickUp);
            Destroy(gameObject);
        }
    }
}