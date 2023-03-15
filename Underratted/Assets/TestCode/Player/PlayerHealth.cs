using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerMovement playerMoveRef;
    public KnockbackTest knock;

    public int maxHealth = 8;
    public float immunityTime = 1f;
    public int healthGainFromCard = 2;
    public int currentHealth;
    

    private bool justAttacked = false;

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
}
