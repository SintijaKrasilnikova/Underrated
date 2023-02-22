using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiState
{
    private bool attacking = false;
    private float timeToAttack = 0.9f;
    private float timer = 0f;

    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("Attack");

        attacking = true;
    }

    public void Update(AiAgent agent)
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;

                attacking = false;
                agent.enemyAnimator.SetBool("Attacking", attacking);


                AiHuntPlayerState huntState = agent.stateMachine.GetState(AiStateId.HuntPlayer) as AiHuntPlayerState;
                agent.stateMachine.ChangeState(AiStateId.HuntPlayer);
            }
        }

        agent.enemyAnimator.SetBool("Attacking", attacking);

    }

    public void Exit(AiAgent agent)
    {
        
    }

}
