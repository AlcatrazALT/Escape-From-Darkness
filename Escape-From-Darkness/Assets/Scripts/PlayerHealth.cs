using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth;
    public GameObject playerDeathFX;
    public GameObject gameOverPanel;

    public Slider playerHealthSlider;
    public Image damageScreen;

    float playerCurrentHealth;
    bool isPlayerTakeDamage = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        PlayerController controlMovement = GetComponent<PlayerController>();
        playerHealthSlider.maxValue = playerCurrentHealth;
        playerHealthSlider.value = playerCurrentHealth;
        isPlayerTakeDamage = false;
    }

    void Update()
    {
        if (isPlayerTakeDamage)
        {
            damageScreen.color = damagedColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        isPlayerTakeDamage = false;
    }

    public void PlayerGetDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }
        playerCurrentHealth -= damage;
        playerHealthSlider.value = playerCurrentHealth;
        FindObjectOfType<AudioManager>().PlayMusic("PlayerHurt");

        isPlayerTakeDamage = true;

        if (playerCurrentHealth <= 0)
        {
            MakePlayerDead();
        }
    }

    public void PlayerGetHealth(float playerHealthAmount)
    {
        playerCurrentHealth += playerHealthAmount;
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        playerHealthSlider.value = playerCurrentHealth;
        FindObjectOfType<AudioManager>().PlayMusic("PlayerPowerUp");
    }

    public void MakePlayerDead()
    {
        Instantiate(playerDeathFX, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().PlayMusic("DeathSound");
        Destroy(gameObject);   
    }
}