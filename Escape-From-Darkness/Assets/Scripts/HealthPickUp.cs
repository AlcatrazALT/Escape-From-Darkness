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

            Destroy(gameObject);
        }
    }
}