using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Health : MonoBehaviour
{

    public int maxHealth = 9;
    public int currentHealth;

    //public Animator currentAnimator;
    AiAgent agent;

    private bool enemiesHealth = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //get the animator of gameObject
        //currentAnimator = gameObject.GetComponent<Animator>();

        if (gameObject.CompareTag("Enemy"))
        {
            if(gameObject.GetComponentInParent<AiAgent>(false))
            {
                Debug.Log("Enemy Found");
                agent = gameObject.GetComponentInParent<AiAgent>(false);
            }
            //agent = gameObject.GetComponent<AiAgent>();
            enemiesHealth = true;
        }
        else
        {
            enemiesHealth = false;
        }

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        //death check
        if( currentHealth <= 0)
        {

            //if health belongs to an enemy
            if (enemiesHealth == true)
            {
                //AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
                //agent.stateMachine.ChangeState(AiStateId.Death);
                //Destroy(gameObject);
            }
        }
        else
        {
            //if health belongs to an enemy
            if (enemiesHealth == true)
            {
                Debug.Log("Health taken");
                //AiHurtingState hurtState = agent.stateMachine.GetState(AiStateId.Hurting) as AiHurtingState;
                agent.stateMachine.ChangeState(AiStateId.Hurting);
                
            }

        }
    }
}
