using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D bulletRB2D;

    void Awake()
    {
        bulletRB2D = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            bulletRB2D.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            bulletRB2D.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    public void RemoveForce()
    {
        bulletRB2D.velocity = new Vector2(0, 0);
    }
}
