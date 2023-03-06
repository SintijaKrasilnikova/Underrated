using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Health : MonoBehaviour
{

    public int maxHealth = 9;
    public int currentHealth;

    //public Animator currentAnimator;
    AiAgent agent;
    PlayerMovement playerMoveRef;

    private bool enemiesHealth = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //get the animator of gameObject
        //currentAnimator = gameObject.GetComponent<Animator>();

        if(gameObject.CompareTag("Player"))
        {

            if (gameObject.GetComponent<PlayerMovement>())
            {

                playerMoveRef = gameObject.GetComponent<PlayerMovement>();
            }

            enemiesHealth = false;

        }
        else //must be enemy
        {
            if(gameObject.GetComponentInParent<AiAgent>(false))
            {
               // Debug.Log("Enemy Found");
                agent = gameObject.GetComponentInParent<AiAgent>(false);
            }
            //agent = gameObject.GetComponent<AiAgent>();
            enemiesHealth = true;
        }

    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            //if health belongs to an enemy
            if (enemiesHealth == true)
            {
                Debug.Log("Health taken");
                currentHealth -= damageAmount;

                AiHurtingState hurtState = agent.stateMachine.GetState(AiStateId.Hurting) as AiHurtingState;
                agent.stateMachine.ChangeState(AiStateId.Hurting);

            }
            else
            {
                currentHealth -= damageAmount;
                playerMoveRef.HurtPlayer(currentHealth);
               
            }


        }
        //else 
        //{
        //    //health belongs to the player
        //    if (enemiesHealth == false)
        //    {
        //        playerMoveRef.KillPlayer();
        //    }
        //}
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
}
