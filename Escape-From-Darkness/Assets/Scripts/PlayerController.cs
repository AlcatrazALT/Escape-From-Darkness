using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement variables
    public float playerMaxSpeed;
    public float playerJumpHeight;

    // jumping variables
    bool isGround = false;
    float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    

    Rigidbody2D playerRb2D;
    Animator playerAnimator;
    bool isPlayerFacingRight;

    // for shooting
    public Transform FirePoint;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        isPlayerFacingRight = true;
    }

    void Update()
    {
        if (isGround && Input.GetAxis("Jump") > 0)
        {
            PlayerJump();
        }

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            PlayerShootBullet();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //check if we are grounded - if no then we are falling
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        playerAnimator.SetBool("IsGrounded", isGround);
        playerAnimator.SetFloat("VerticalSpeed", playerRb2D.velocity.y);

        float move = Input.GetAxis("Horizontal");
        playerRb2D.velocity = new Vector2(move * playerMaxSpeed, playerRb2D.velocity.y);
        playerAnimator.SetFloat("Speed", Mathf.Abs(move));
        if (move > 0 && !isPlayerFacingRight)
        {
            PlayerFlip();
        }
        else if(move < 0 && isPlayerFacingRight)
        {
            PlayerFlip();
        }
    }

    

    void PlayerJump() // прыжок
    {
        isGround = false;
        playerAnimator.SetBool("IsGrounded", isGround);
        playerRb2D.AddForce(new Vector2(0, playerJumpHeight));
    }


    void PlayerFlip() // поворот персонажа
    {
        isPlayerFacingRight = !isPlayerFacingRight;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    }

    void PlayerShootBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if(isPlayerFacingRight)
            {
                Instantiate(bullet, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if(!isPlayerFacingRight)
            {
                Instantiate(bullet, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}