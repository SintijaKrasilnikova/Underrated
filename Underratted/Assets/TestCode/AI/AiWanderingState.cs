using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWanderingState : AiState
{

    private Vector3 desiredPositionPos;
    private Vector3 desiredPositionNeg;

    //private Vector2 playerPosXZ;
    //private float posDiffX;
    //private float posDiffZ;


    private bool currentDirectionLeft;

    public AiStateId GetId()
    {
        return AiStateId.Wander;
    }

    public void Enter(AiAgent agent)
    {
        //Debug.Log("Wandering");

        //Vector3 stoppingDist = new Vector3(agent.navAgent.stoppingDistance, agent.navAgent.stoppingDistance, agent.navAgent.stoppingDistance);
        desiredPositionNeg = agent.startPositionEnemy - agent.config.wanderDistance;
        desiredPositionPos = agent.startPositionEnemy + agent.config.wanderDistance;

        currentDirectionLeft = agent.startWanderingLeft;

        agent.navAgent.stoppingDistance = 0;

        if (currentDirectionLeft == true)
        {
            agent.navAgent.destination = desiredPositionNeg;
            agent.enemyAnimator.SetFloat("FacingRight", -1);
            agent.enemyAnimator.SetFloat("FacingUp", 0);
        }
        else
        {
            agent.navAgent.destination = desiredPositionPos;
            agent.enemyAnimator.SetFloat("FacingRight", 1);
            agent.enemyAnimator.SetFloat("FacingUp", 0);
        }
    }

    public void Update(AiAgent agent)
    {
       
        if (Mathf.Abs(agent.playerTransform.position.x - agent.navAgent.stoppingDistance - agent.transform.position.x) < agent.config.huntingDistance 
            && Mathf.Abs(agent.playerTransform.position.z - agent.navAgent.stoppingDistance - agent.transform.position.z) < agent.config.huntingDistance)
        {
            AiHuntPlayerState huntState = agent.stateMachine.GetState(AiStateId.HuntPlayer) as AiHuntPlayerState;
            agent.stateMachine.ChangeState(AiStateId.HuntPlayer);
        }

        //Debug.Log("Moving");
        agent.enemyAnimator.SetBool("Moving", true);

        //left
        if (currentDirectionLeft == true)
        {
            //agent.navAgent.destination = desiredPositionNeg;

            if (agent.transform.position.x == desiredPositionNeg.x  && 
                agent.transform.position.z == desiredPositionNeg.z )
            {
                currentDirectionLeft = false;
                agent.navAgent.destination = desiredPositionPos;
                agent.enemyAnimator.SetFloat("FacingRight", 1);
                agent.enemyAnimator.SetFloat("FacingUp", 0);
            }

        }
        else //right
        {
            //agent.navAgent.destination = desiredPositionPos;

            if (agent.transform.position.x  == desiredPositionPos.x  && 
                agent.transform.position.z  == desiredPositionPos.z )
            {
                currentDirectionLeft = true;
                agent.navAgent.destination = desiredPositionNeg;
                agent.enemyAnimator.SetFloat("FacingRight", -1);
                agent.enemyAnimator.SetFloat("FacingUp", 0);
            }
        }


    }

    public void Exit(AiAgent agent)
    {
       
    }

  
}
