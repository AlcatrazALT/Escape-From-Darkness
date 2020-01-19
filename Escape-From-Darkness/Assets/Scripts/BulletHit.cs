using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float bulletDamage;
    public GameObject explosionEffect;
    BulletController bulletBC;

    void Start()
    {
        bulletBC = GetComponentInParent<BulletController>();
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            bulletBC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(otherCollider.tag == "Enemy")
            {
                EnemyHealth enemyHurt = otherCollider.gameObject.GetComponent<EnemyHealth>();
                enemyHurt.EnemyGetDamage(bulletDamage);
                FindObjectOfType<AudioManager>().PlayMusic("ExplosionEffect");
            }
        }
    }
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            bulletBC.RemoveForce();
            
            Instantiate(explosionEffect, transform.position, transform.rotation);
            
            Destroy(gameObject);
            if (otherCollider.tag == "Enemy")
            {
                EnemyHealth enemyHurt = otherCollider.gameObject.GetComponent<EnemyHealth>();
                enemyHurt.EnemyGetDamage(bulletDamage);
            }
        }
        else if(otherCollider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            bulletBC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().PlayMusic("ExplosionEffect");
            Destroy(gameObject);
        }
    }
}
