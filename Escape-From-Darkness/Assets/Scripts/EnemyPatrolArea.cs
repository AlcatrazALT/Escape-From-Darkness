using UnityEngine;

public class EnemyPatrolArea : MonoBehaviour
{
    public float enemyMaxSpeed;
    public bool isEnemyMovingRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;
    private bool isEdge;
    Rigidbody2D enemyRB2D;
    
    public Transform edgeCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        isEdge = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !isEdge)
        {
            isEnemyMovingRight = !isEnemyMovingRight;
        }
        if (isEnemyMovingRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            enemyRB2D.AddForce(new Vector2(1, 0) * enemyMaxSpeed);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            enemyRB2D.AddForce(new Vector2(-1, 0) * enemyMaxSpeed);
        }
    }
}
