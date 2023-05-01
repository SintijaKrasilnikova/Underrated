using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth = 9;
    public float currentHealth;

    AiAgent agent;

    public AK.Wwise.Event hitSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        if (gameObject.CompareTag("Enemy"))
        {
            if (gameObject.GetComponentInParent<AiAgent>(false))
            {
                agent = gameObject.GetComponentInParent<AiAgent>(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float damageAmount)
    {
        if (currentHealth > 0)
        {
            Debug.Log("Health taken");
            currentHealth -= damageAmount;
            hitSound.Post(gameObject);
            AiHurtingState hurtState = agent.stateMachine.GetState(AiStateId.Hurting) as AiHurtingState;
            agent.stateMachine.ChangeState(AiStateId.Hurting);
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
