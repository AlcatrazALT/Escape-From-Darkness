using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player")
        {
            PlayerScoreManager.AddPlayerPoint(pointsToAdd);
            GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().coinPickUp);
            Destroy(gameObject);
        }
    }
}
