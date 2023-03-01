using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHurtingState : AiState
{

    private float hurtTime = 0.5f;
    private float timer = 0f;

    public AiStateId GetId()
    {
        return AiStateId.Hurting;
    }

    public void Enter(AiAgent agent)
    {
        //Debug.Log("Hurting");
        agent.enemyAnimator.SetBool("Hurt", true);
        timer = 0f;
    }

    public void Update(AiAgent agent)
    {
        if (timer < hurtTime)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer");
        }
        else
        {
            AiHuntPlayerState huntState = agent.stateMachine.GetState(AiStateId.HuntPlayer) as AiHuntPlayerState;
            agent.stateMachine.ChangeState(AiStateId.HuntPlayer);
        }
    }

    public void Exit(AiAgent agent)
    {
        agent.enemyAnimator.SetBool("Hurt", false);
    }

}
