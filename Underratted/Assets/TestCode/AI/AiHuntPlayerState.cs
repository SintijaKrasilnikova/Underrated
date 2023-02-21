using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHuntPlayerState : AiState
{
    public Transform playerTransform;
    private Vector3 startPosition;
    private bool isHunting = false;

    public AiStateId GetId()
    {
        return AiStateId.HuntPlayer;
    }
   
    public void Enter(AiAgent agent)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = playerTransform.position;

    }
    public void Update(AiAgent agent)
    {

        agent.navAgent.destination = playerTransform.position;

        isHunting = true;
        agent.enemyAnimator.SetBool("Hunting", isHunting);

        //left
        if (playerTransform.position.x < agent.transform.localPosition.x)
        {
            agent.enemyAnimator.SetFloat("FacingRight", -1);
            agent.enemyAnimator.SetFloat("FacingUp", 0);
            //Debug.Log("Left");
        }
        else
        {
            agent.enemyAnimator.SetFloat("FacingRight", 1);
            agent.enemyAnimator.SetFloat("FacingUp", 0); 
            //Debug.Log("Right");
        }

        if(agent.navAgent.velocity == Vector3.zero && isHunting == true)
        {
            AiAttackState attackState = agent.stateMachine.GetState(AiStateId.Attack) as AiAttackState;
            agent.stateMachine.ChangeState(AiStateId.Attack);
        }

    }

    public void Exit(AiAgent agent)
    {
        
    }

}
