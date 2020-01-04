using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyDamage;
    public float enemyDamageRate;
    public float enemyPushBackForce;

    float nextDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player" && nextDamage <= Time.time)
        {
            PlayerHealth playerHealth = otherCollider.gameObject.GetComponent<PlayerHealth>();
            playerHealth.PlayerGetDamage(enemyDamage);
            nextDamage = Time.time + enemyDamageRate;
            PushBack(otherCollider.transform);
        }
    }

    void PushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= enemyPushBackForce;
        Rigidbody2D pushRB2D = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB2D.velocity = Vector2.zero;
        pushRB2D.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
