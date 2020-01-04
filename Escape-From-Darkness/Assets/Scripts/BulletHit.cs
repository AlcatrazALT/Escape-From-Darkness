using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float bulletDamage;
    public GameObject explosionEffect;
    BulletController bulletBC;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletBC = GetComponentInParent<BulletController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
