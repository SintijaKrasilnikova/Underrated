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
    private float attackCoolDown = 0;

    public AiStateId GetId()
    {
        return AiStateId.Wander;
    }

    public void Enter(AiAgent agent)
    {
        //Debug.Log("Wandering");

        //Vector3 stoppingDist = new Vector3(agent.navAgent.stoppingDistance, agent.navAgent.stoppingDistance, agent.navAgent.stoppingDistance);


        currentDirectionLeft = agent.startWanderingLeft;
        //if enemy wanders left to right
        if (agent.config.doesEnemyMove == true)
        {
            desiredPositionNeg = agent.startPositionEnemy - agent.config.wanderDistance;
            desiredPositionPos = agent.startPositionEnemy + agent.config.wanderDistance;



            agent.navAgent.stoppingDistance = 0;

            if (currentDirectionLeft == true)
            {
                agent.navAgent.destination = desiredPositionNeg;

            }
            else
            {
                agent.navAgent.destination = desiredPositionPos;
            }
        }

        if (currentDirectionLeft == true)
        {
            agent.enemyAnimator.SetFloat("FacingRight", -1);
            agent.enemyAnimator.SetFloat("FacingUp", 0);
        }
        else
        {
            agent.enemyAnimator.SetFloat("FacingRight", 1);
            agent.enemyAnimator.SetFloat("FacingUp", 0);
        }
    }

    public void Update(AiAgent agent)
    {
        //float cspeed = agent.navAgent.speed;
        //Debug.Log(cspeed);
        //if enemy moves
        if (agent.config.doesEnemyMove == true)
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

                if (agent.transform.position.x == desiredPositionNeg.x &&
                    agent.transform.position.z == desiredPositionNeg.z)
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

                if (agent.transform.position.x == desiredPositionPos.x &&
                    agent.transform.position.z == desiredPositionPos.z)
                {
                    currentDirectionLeft = true;
                    agent.navAgent.destination = desiredPositionNeg;
                    agent.enemyAnimator.SetFloat("FacingRight", -1);
                    agent.enemyAnimator.SetFloat("FacingUp", 0);
                }
            }
        }
        else //enemy is static and waits for player to come close
        {

            //if enemy doesnt move, it kips the hunting stage so the attack cooldown has to be calculated here
            if (agent.readyToAttack == true)
            {
                if (Mathf.Abs(agent.playerTransform.position.x - agent.transform.position.x) < agent.config.huntingDistance
                 && Mathf.Abs(agent.playerTransform.position.z - agent.transform.position.z) < agent.config.huntingDistance)
                {
                    AiAttackState attackState = agent.stateMachine.GetState(AiStateId.Attack) as AiAttackState;
                    agent.stateMachine.ChangeState(AiStateId.Attack);
                }
            }
            else
            {
                if (attackCoolDown > agent.config.attackCooldown)
                {
                    attackCoolDown = 0f;
                    agent.readyToAttack = true;
                }
                else
                    attackCoolDown += Time.deltaTime;
            }

            

        }

    }

    public void Exit(AiAgent agent)
    {
       
    }

  
}
