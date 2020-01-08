using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretShoot : MonoBehaviour
{

    public GameObject turretBullet;
    public float turretShootTime;
    public int turretChanceShoot;
    public Transform turretShootFrom;
    
    float nextShootTime;
    Animator turretAnimator;

    // Start is called before the first frame update
    void Start()
    {
        turretAnimator = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + turretShootTime;
            if(Random.Range(0, 10) >= turretChanceShoot)
            {
                Instantiate(turretBullet, turretShootFrom.position, Quaternion.identity);
                turretAnimator.SetTrigger("isCannonShoot");
            }
        }
    }
}
