using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{

    private float deathTime = 0.5f;
    private float deathTimer = 0f;

    private EnemyDeath death;

    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(AiAgent agent)
    {
        death = agent.GetComponentInChildren<EnemyDeath>();

        Debug.Log("Died");
        deathTimer = 0f;
        agent.enemyAnimator.SetBool("Dying", true);
    }

    public void Update(AiAgent agent)
    {
        deathTimer += Time.deltaTime;

        if (deathTimer > deathTime)
        {
            //agent.GetComponent<CardRandomDropper>().ChanceToDropCard(100, "");
            agent.GetComponent<CardRandomDropper>().ChanceToDropCard();
            death.Death();
            agent.gameObject.SetActive(false);
        }
       
    }

    public void Exit(AiAgent agent)
    {

        agent.gameObject.SetActive(false);
    }
}
