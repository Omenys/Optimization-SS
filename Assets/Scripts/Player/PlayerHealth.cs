using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    //public int startingHealth = 100;
    //public int currentHealth;

    // Moved to Health UI script
    /*public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);*/


    bool damaged;


    public AudioClip deathClip;


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;

    public HealthData maxHealth;
    public HealthData currHealth;
    public HealthUI healthUI;

    bool isDead;

    int id_die = Animator.StringToHash("Die");

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();

        //currentHealth = startingHealth;
        currHealth.amount = maxHealth.amount;
    }


    /*void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }*/


    public void TakeDamage(int amount)
    {
        damaged = true;
        currHealth.amount -= amount;
        healthUI.healthSlider.value = currHealth.amount;

        playerAudio.Play();

        if (currHealth.amount <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger(id_die);

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
