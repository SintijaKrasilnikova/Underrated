using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AiHuntPlayerState : AiState
{
    //public Transform playerTransform;
    private Vector3 startPosition;
    private bool isHunting = false;

    
    private float attackCoolDown;
    private float chargePrepTime = 0.7f;
    private float chargeTimer = 0f;
    private Vector3 playerPosWhenSpotted;
    private float startSpeed;
    private float increasedSpeed;
    private Vector3 attackTargetPos;

    private float turnPauseTime = 1.5f;
    private float pauseTimer = 0.0f;

    private bool canTurn = true;
    private bool chargeDone = false;

    public AiStateId GetId()
    {
        return AiStateId.HuntPlayer;
    }
   
    public void Enter(AiAgent agent)
    {
        //Debug.Log("Hunting");

        //agent.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = agent.playerTransform.position;

        agent.navAgent.stoppingDistance = agent.config.huntingStopDistance;

        //if(agent.config.enemyIsBeetle == true)
        //{
        //    agent.navAgent.destination = agent.playerTransform.position;
        //}
        chargeDone = false;
        playerPosWhenSpotted = agent.playerTransform.position;
        attackCoolDown = 0f;
        chargeTimer = 0f;
        startSpeed = agent.navAgent.speed;
        increasedSpeed = startSpeed + agent.config.chargeSpeedIncrease;
        if (agent.config.enemyIsBeetle == true)
            attackTargetPos = playerPosWhenSpotted;
    }
    public void Update(AiAgent agent)
    {
        if (agent.config.enemyIsBeetle == true && chargeDone == false)
        {
            if (chargeTimer < chargePrepTime)
            {
                chargeTimer += Time.deltaTime;
                agent.navAgent.speed = 0;
                agent.enemyAnimator.SetBool("Charging", true);
                //Debug.Log(chargeTimer);
            }
            else
            {
                agent.navAgent.destination = playerPosWhenSpotted;
                agent.navAgent.speed = increasedSpeed;
                agent.enemyAnimator.SetBool("Charging", false);
                chargeDone = true;
                //Debug.Log("ChargeEnd");
            }
        }
        else
        {
            //attackTargetPos = agent.playerTransform.position;
            //agent.navAgent.destination = agent.playerTransform.position;
        }

        Debug.Log(agent.readyToAttack);

        if (agent.config.enemyIsBeetle == false)
        {
            agent.navAgent.destination = agent.playerTransform.position;
        }

        if(chargeDone == true && agent.config.enemyIsBeetle == true)
        {
            agent.enemyAnimator.SetBool("Charging", false);
        }
        else
        {
            agent.navAgent.speed = 0;
        }

        //agent.navAgent.destination = agent.playerTransform.position;

        isHunting = true;
        agent.enemyAnimator.SetBool("Hunting", isHunting);
        agent.enemyAnimator.SetBool("Moving", isHunting);

        //if (canTurn == false)
        //{
        //    if (pauseTimer > turnPauseTime)
        //    {
        //        pauseTimer = 0f;
        //        canTurn = true;
        //        //agent.readyToAttack = true;

        //    }
        //    else
        //        pauseTimer += Time.deltaTime;
        //}

        //left
        //if (agent.playerTransform.position.x < agent.transform.localPosition.x)
        //if (canTurn)
        //{
            if (agent.navAgent.destination.x < agent.transform.localPosition.x)
            {
                canTurn = false;
                agent.enemyAnimator.SetFloat("FacingRight", -1);
                agent.enemyAnimator.SetFloat("FacingUp", 0);
                agent.startWanderingLeft = true;
                //Debug.Log("Left");
            }
            else
            {
                canTurn = false;
                agent.enemyAnimator.SetFloat("FacingRight", 1);
                agent.enemyAnimator.SetFloat("FacingUp", 0);
                agent.startWanderingLeft = false;
                //Debug.Log("Right");
            }
        //}



        //if(agent.navAgent.velocity == Vector3.zero && isHunting == true)
        //{
        //    AiAttackState attackState = agent.stateMachine.GetState(AiStateId.Attack) as AiAttackState;
        //    agent.stateMachine.ChangeState(AiStateId.Attack);
        //}

        if (agent.config.enemyIsBeetle == true && chargeDone == true)
        {
            agent.readyToAttack = true;
        }

        if (agent.readyToAttack == true)
        {
            if (Mathf.Abs(attackTargetPos.x - agent.transform.position.x) < agent.navAgent.stoppingDistance
                && Mathf.Abs(attackTargetPos.z - agent.transform.position.z) < agent.navAgent.stoppingDistance)
            {
                agent.navAgent.speed = startSpeed;
                AiAttackState attackState = agent.stateMachine.GetState(AiStateId.Attack) as AiAttackState;
                agent.stateMachine.ChangeState(AiStateId.Attack);
            }

            //if (Mathf.Abs(agent.playerTransform.position.x - agent.transform.position.x) < agent.navAgent.stoppingDistance
            //    && Mathf.Abs(agent.playerTransform.position.z - agent.transform.position.z) < agent.navAgent.stoppingDistance)
        }
        else
        {
            if(attackCoolDown> agent.config.attackCooldown)
            {
                attackCoolDown = 0f;
                agent.readyToAttack = true;
            }
            else
                attackCoolDown += Time.deltaTime;
        }

        if (Mathf.Abs(attackTargetPos.x - agent.navAgent.stoppingDistance - agent.transform.position.x) > agent.config.huntingDistance
            && Mathf.Abs(attackTargetPos.z - agent.navAgent.stoppingDistance - agent.transform.position.z) > agent.config.huntingDistance)
        {
            agent.navAgent.speed = startSpeed;
            AiWanderingState wanderState = agent.stateMachine.GetState(AiStateId.Wander) as AiWanderingState;
            agent.stateMachine.ChangeState(AiStateId.Wander);

            //if (Mathf.Abs(agent.playerTransform.position.x - agent.navAgent.stoppingDistance - agent.transform.position.x) > agent.config.huntingDistance
            //&& Mathf.Abs(agent.playerTransform.position.z - agent.navAgent.stoppingDistance - agent.transform.position.z) > agent.config.huntingDistance)
        }

    }

    public void Exit(AiAgent agent)
    {
        //agent.navAgent.speed = startSpeed;
    }


}
