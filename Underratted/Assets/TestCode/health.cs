using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class health : MonoBehaviour
{

    public int maxHealth = 9;
    public int currentHealth;

    public Animator currentAnimator;
    AiAgent agent;

    private bool enemiesHealth = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //get the animator of gameObject
        currentAnimator = gameObject.GetComponent<Animator>();

        if (gameObject.CompareTag("Enemy"))
        {
            agent = gameObject.GetComponent<AiAgent>();
            enemiesHealth = true;
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
    }
}
