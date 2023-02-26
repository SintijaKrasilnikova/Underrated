using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHuntPlayerState : AiState
{
    //public Transform playerTransform;
    private Vector3 startPosition;
    private bool isHunting = false;

    public AiStateId GetId()
    {
        return AiStateId.HuntPlayer;
    }
   
    public void Enter(AiAgent agent)
    {
        Debug.Log("Hunting");

        //agent.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = agent.playerTransform.position;

        agent.navAgent.stoppingDistance = agent.config.huntingStopDistance;

    }
    public void Update(AiAgent agent)
    {

        agent.navAgent.destination = agent.playerTransform.position;

        isHunting = true;
        agent.enemyAnimator.SetBool("Hunting", isHunting);
        agent.enemyAnimator.SetBool("Moving", isHunting);

        //left
        if (agent.playerTransform.position.x < agent.transform.localPosition.x)
        {
            agent.enemyAnimator.SetFloat("FacingRight", -1);
            agent.enemyAnimator.SetFloat("FacingUp", 0);
            agent.startWanderingLeft = true;
            //Debug.Log("Left");
        }
        else
        {
            agent.enemyAnimator.SetFloat("FacingRight", 1);
            agent.enemyAnimator.SetFloat("FacingUp", 0);
            agent.startWanderingLeft = false;
            //Debug.Log("Right");
        }

        //if(agent.navAgent.velocity == Vector3.zero && isHunting == true)
        //{
        //    AiAttackState attackState = agent.stateMachine.GetState(AiStateId.Attack) as AiAttackState;
        //    agent.stateMachine.ChangeState(AiStateId.Attack);
        //}

        if (Mathf.Abs(agent.playerTransform.position.x - agent.transform.position.x) < agent.navAgent.stoppingDistance
            && Mathf.Abs(agent.playerTransform.position.z - agent.transform.position.z) < agent.navAgent.stoppingDistance)
        {
            AiAttackState attackState = agent.stateMachine.GetState(AiStateId.Attack) as AiAttackState;
            agent.stateMachine.ChangeState(AiStateId.Attack);
        }

        if (Mathf.Abs(agent.playerTransform.position.x - agent.navAgent.stoppingDistance - agent.transform.position.x) > agent.config.huntingDistance
            && Mathf.Abs(agent.playerTransform.position.z - agent.navAgent.stoppingDistance - agent.transform.position.z) > agent.config.huntingDistance)
        {
            AiWanderingState wanderState = agent.stateMachine.GetState(AiStateId.Wander) as AiWanderingState;
            agent.stateMachine.ChangeState(AiStateId.Wander);
        }

    }

    public void Exit(AiAgent agent)
    {
        
    }

}
