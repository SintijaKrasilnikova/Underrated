using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerMovement playerMoveRef;
    [SerializeField] private GameObject pickup;
    [SerializeField] private KnockbackTest knock;

    public int maxHealth = 8;
    public float immunityTime = 1f;
    public int healthGainFromPickup = 2;
    public int healthPickupChance = 20;
    public int healthGainFromCard = 2;
    public int healthGainFromSteal = 2;
    public int healthStealChance = 20;
    public int currentHealth;
    

    private bool justAttacked = false;
    private bool lifeStealActive = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        if (gameObject.CompareTag("Player"))
        {

            if (gameObject.GetComponent<PlayerMovement>())
            {

                playerMoveRef = gameObject.GetComponent<PlayerMovement>();
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (justAttacked == false)
        {
            currentHealth -= damageAmount;
            knock.Knockback();
            playerMoveRef.HurtPlayer(currentHealth);
            justAttacked = true;

            Invoke(nameof(BeImmune), immunityTime);
        }
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
    }

    public void LifeSteal()
    {
        int randomChance = Random.Range(1, 100);

        if (lifeStealActive && randomChance < healthStealChance)
        {
            currentHealth += healthGainFromSteal;
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
        currentHealth += healthGainFromPickup;
    }

    public void SetLifestealActive()
    {
        lifeStealActive = true;
    }

    public void IncreaseHealthPickupRate()
    {
        healthPickupChance += 10;
    }
}
