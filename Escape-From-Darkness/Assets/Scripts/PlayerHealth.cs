using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth;
    public GameObject playerDeathFX;
    public AudioClip playerAudioHurt;


    float playerCurrentHealth;
    PlayerController controlMovement;
    AudioSource playerAudioSource;

    //HUD
    public Slider playerHealthSlider;
    public Image damageScreen;

    bool isPlayerTakeDamage = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        controlMovement = GetComponent<PlayerController>();

        playerHealthSlider.maxValue = playerCurrentHealth;
        playerHealthSlider.value = playerCurrentHealth;

        isPlayerTakeDamage = false;

        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
        
        playerAudioSource.PlayOneShot(playerAudioHurt);
        playerHealthSlider.value = playerCurrentHealth;
        isPlayerTakeDamage = true;

        if (playerCurrentHealth <= 0)
        {
            MakePlayerDead();
        }
    }
    public void MakePlayerDead()
    {
        Instantiate(playerDeathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
