using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{

    private float deathTime = 0.5f;
    private float deathTimer = 0f;
    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(AiAgent agent)
    {
        Debug.Log("Died");
        deathTimer = 0f;
        agent.enemyAnimator.SetBool("Dying", true);
    }

    public void Update(AiAgent agent)
    {
        deathTimer += Time.deltaTime;

        if (deathTimer > deathTime)
        {
            agent.GetComponent<CardRandomDropper>().chanceToDropCard(90);
            agent.gameObject.SetActive(false);
        }
       
    }

    public void Exit(AiAgent agent)
    {

        //agent.gameObject.SetActive(false);
    }
}
