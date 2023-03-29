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
    public int healthPickupChance = 100;
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

    //public void HealthPickUp()
    //{
    //    int randomChance = Random.Range(1, 100);

    //    if (randomChance < healthPickupChance)
    //    {
    //        Instantiate(pickup, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y , gameObject.transform.position.z), Quaternion.identity);
    //        //currentHealth += healthGainFromPickup;
    //    }
    //}

    public void SetLifestealActive()
    {
        lifeStealActive = true;
    }

    public void IncreaseHealthPickupRate()
    {
        healthPickupChance += 10;
    }
}
