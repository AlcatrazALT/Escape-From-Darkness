using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    public GameObject enemyDeathFX;
    public Slider enemyHealthSlider;

    float enemyCurrentHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = enemyCurrentHealth;
        enemyHealthSlider.value = enemyCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyGetDamage(float bulletdamage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        enemyCurrentHealth -= bulletdamage;
        enemyHealthSlider.value = enemyCurrentHealth;
        if(enemyCurrentHealth <= 0)
        {
            MakeEnemyDead();
        }
    }

    void MakeEnemyDead()
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
    }
}
