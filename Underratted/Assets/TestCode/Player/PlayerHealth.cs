using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerMovement playerMoveRef;
    [SerializeField] private GameObject pickup;
    [SerializeField] private KnockbackTest knock;
    [SerializeField] private CardOverseer overSeer;
    private CapsuleCollider playerCapsule;
    private SpriteRenderer playerSprite;

    public int maxHealth = 4;
    public int maxHealthLimit = 8;
    public float immunityTime = 1f;
    public int healthGainFromPickup = 2;
    public int healthPickupChance = 10;
    public int healthPickupChanceCap = 50;
    public int healthGainFromCard = 2;
    public int healthGainFromSteal = 2;
    public int healthStealChance = 20;
    public int healthStealChanceCap = 50;
    public int currentHealth;

    private bool endScreen = false;
    

    private bool justAttacked = false;
    private bool lifeStealActive = false;

    private bool dead = false;

    public bool isTutorial = false;

    public GameObject healVFX;

    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;

        //if(overSeer.StartHealthSet == true)
        //    currentHealth = overSeer.CurrentHealth;
        //else
        //    currentHealth = maxHealth;
        dead = false;
        currentHealth = overSeer.CurrentHealth;
        endScreen = false;

        if (gameObject.CompareTag("Player"))
        {

            if (gameObject.GetComponent<PlayerMovement>())
            {

                playerMoveRef = gameObject.GetComponent<PlayerMovement>();
                playerCapsule = gameObject.GetComponent<CapsuleCollider>();
                playerSprite = gameObject.GetComponent<SpriteRenderer>();
            }
        }


    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            dead = true;
            justAttacked = true;
            //playerCapsule.enabled = false;
        }

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (overSeer.runStarted)
        {
            overSeer.runStarted = false;
            currentHealth = maxHealth;
            isTutorial = false;
        }

        if(justAttacked)
        {
            playerSprite = gameObject.GetComponent<SpriteRenderer>();
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.b, playerSprite.color.g, 0.5f);
        }

        
    }

    public void SetEndScreen(bool IsScreenActive)
    {
        endScreen = IsScreenActive;
        justAttacked = IsScreenActive;
    }

    public bool IsLuluDead()
    {
        return dead;
    }

    public void SetCurrentHealthToMax()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (justAttacked == false && endScreen == false)
        {
            currentHealth -= damageAmount;
            knock.Knockback();
            playerMoveRef.HurtPlayer(currentHealth);
            justAttacked = true;

            if(currentHealth <= 0)
                dead = true;

            overSeer.CurrentHealth = currentHealth;
            CallHealthImunity();
            //Invoke(nameof(BeImmune), immunityTime);
        }
    }

    //public void CallImunity()
    //{
    //    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.b, playerSprite.color.g, 0.5f);

    //    justAttacked = true;
    //    Invoke(nameof(BeImmune), immunityTime);
    //}

    public void CallHealthImunity()
    {
        StartImunity();
        Invoke(nameof(EndImunity), immunityTime);
    }

    public void StartImunity()
    {
        justAttacked = true;
    }

    public void EndImunity()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.b, playerSprite.color.g, 1f);
        justAttacked = false;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }


    //public void BeImmune()
    //{
    //    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.b, playerSprite.color.g, 1f);
    //    justAttacked = false;
    //}

    public void AddHealth()
    {
        currentHealth += healthGainFromCard;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        overSeer.CurrentHealth = currentHealth;
    }

    public void IncreaseHealthSteal(int stealInc)
    {
        if (healthStealChance < healthStealChanceCap)
            healthStealChance += stealInc;

    }

    public void LifeSteal()
    {
        int randomChance = Random.Range(1, 100);

        if (lifeStealActive && randomChance < healthStealChance)
        {
            Instantiate(healVFX, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z), gameObject.transform.rotation);
            currentHealth += healthGainFromSteal;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        overSeer.CurrentHealth = currentHealth;
    }

    public void HealthPickUp(Vector3 enemyPos)
    {
        int randomChance = Random.Range(1, 100);

        if (randomChance < healthPickupChance)
        {
            Instantiate(pickup, enemyPos, Quaternion.identity);
        }
    }

    public void GainHealthFromPickup()
    {
        Instantiate(healVFX, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z), gameObject.transform.rotation);

        if (currentHealth <= maxHealth)
        {
            currentHealth += healthGainFromPickup;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        overSeer.CurrentHealth = currentHealth;

    }

    public void SetLifestealActive()
    {
        lifeStealActive = true;
    }

    public void IncreaseHealthPickupRate()
    {
        if(healthPickupChance <healthPickupChanceCap)
            healthPickupChance += 10;
    }

    public void IncreaseMaxHealth(int healthInc)
    {
        maxHealth += healthInc;

        if(maxHealth > maxHealthLimit)
            maxHealth= maxHealthLimit;

    }
}
