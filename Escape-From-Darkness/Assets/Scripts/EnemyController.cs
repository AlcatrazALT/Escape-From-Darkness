using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemyMaxSpeed;
    
    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
    bool isEnemyCanFlip = true;
    bool isEnemyFacingRight = false;
    float enemyFlipTime = 5f;
    float enemyNextFlipChance = 0f;

    //attacking
    public float enemyChargeTime;
    float startChargeTime;
    bool isEnemyCharging;
    Rigidbody2D enemyRB2D;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > enemyNextFlipChance)
        {
            if(Random.Range(0, 10) >= 5)
            {
                EnemyFlip();
            }
            enemyNextFlipChance = Time.time + enemyFlipTime;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player")
        {
            if(isEnemyFacingRight && otherCollider.transform.position.x < transform.position.x)
            {
                EnemyFlip();
            }
            else if(!isEnemyFacingRight && otherCollider.transform.position.x > transform.position.x)
            {
                EnemyFlip();
            }
            isEnemyCanFlip = false;
            isEnemyCharging = true;
            startChargeTime = Time.time + enemyChargeTime;
        }
    }
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            isEnemyCanFlip = true;
            isEnemyCharging = false;
            enemyRB2D.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("isCharging", isEnemyCharging);
        }
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            if(startChargeTime <= Time.time)
            {
                if(!isEnemyFacingRight)
                {
                    enemyRB2D.AddForce(new Vector2(-1, 0) * enemyMaxSpeed);
                }
                else
                {
                    enemyRB2D.AddForce(new Vector2(1, 0) * enemyMaxSpeed);
                }
                enemyAnimator.SetBool("isCharging", isEnemyCharging);
            }
        }
    }

    void EnemyFlip()
    {
        if (!isEnemyCanFlip) return;
        float enemyFacingX = enemyGraphic.transform.localScale.x;
        enemyFacingX *= -1;
        enemyGraphic.transform.localScale = new Vector3(enemyFacingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        isEnemyFacingRight = !isEnemyFacingRight;
    }
}
