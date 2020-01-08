using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    public GameObject enemyDeathFX;
    public Slider enemyHealthSlider;
    public bool isEnemyCanDrop;
    public GameObject theDrop;

    float enemyCurrentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = enemyCurrentHealth;
        enemyHealthSlider.value = enemyCurrentHealth;
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
        Destroy(gameObject.transform.parent.gameObject);
        GameObject.Find("AudioBox").GetComponent<AudioBox>().AudioPlay(GameObject.Find("AudioBox").GetComponent<AudioBox>().enemyDead);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if(isEnemyCanDrop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
}
