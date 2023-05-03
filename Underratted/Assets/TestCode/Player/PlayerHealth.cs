using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerMovement playerMoveRef;
    [SerializeField] private GameObject pickup;
    [SerializeField] private KnockbackTest knock;
    [SerializeField] private CardOverseer overSeer;

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
    

    private bool justAttacked = false;
    private bool lifeStealActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;

        //if(overSeer.StartHealthSet == true)
        //    currentHealth = overSeer.CurrentHealth;
        //else
        //    currentHealth = maxHealth;

        currentHealth = overSeer.CurrentHealth;

        if (gameObject.CompareTag("Player"))
        {

            if (gameObject.GetComponent<PlayerMovement>())
            {

                playerMoveRef = gameObject.GetComponent<PlayerMovement>();
            }
        }
    }

    public void SetCurrentHealthToMax()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (justAttacked == false)
        {
            currentHealth -= damageAmount;
            knock.Knockback();
            playerMoveRef.HurtPlayer(currentHealth);
            justAttacked = true;

            CallImunity();
            //Invoke(nameof(BeImmune), immunityTime);
        }
    }

    public void CallImunity()
    {
        justAttacked = true;
        Invoke(nameof(BeImmune), immunityTime);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void BeImmune()
    {
        justAttacked = false;
    }

    public void AddHealth()
    {
        currentHealth += healthGainFromCard;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
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
            currentHealth += healthGainFromSteal;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
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
        if (currentHealth <= maxHealth)
        {
            currentHealth += healthGainFromPickup;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

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
