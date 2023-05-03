using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiAttackState : AiState
{
    private bool attacking = false;
    //private float timeToAttack = 0.9f;
    
    private float timer = 0f;
    private float areaTimer = 0f;
    private GameObject attackArea = default;
    private bool areaActive = false;
    private GameObject stinger;

    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }

    public void Enter(AiAgent agent)
    {
        //Debug.Log("Attack");
        if(agent.config.enemyIsBeetle == true)
        {
            stinger = agent.transform.GetChild(3).gameObject;
            stinger.SetActive(false);

        }


        attacking = true;
        agent.readyToAttack = false;

        timer = 0f;
        areaTimer = 0f;
        areaActive = false;

        if (agent.transform.GetChild(0).gameObject.tag == "AttackArea")
        {
            attackArea = agent.transform.GetChild(0).gameObject;
            
        }
        else
        {
            Debug.Log("Attack area not found!");
        }


        if (agent.config.doesEnemyMove == false)
        {
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
        }
        Debug.Log("EnterAttack");
        //attackArea = agent.transform.GetComponentInChildren<BoxCollider>();
    }

    public void Update(AiAgent agent)
    {
        if (attacking)
        {
            timer += Time.deltaTime;
            areaTimer += Time.deltaTime;

            if( timer > agent.config.attackPrepare && areaActive == false)
            {
                areaActive = true;
                attackArea.SetActive(true);
                //Debug.Log(timer);

            }
           
            if(areaTimer > agent.config.attackAreaDuraton)
            {
                attackArea.SetActive(false);
            }

            if (timer >= agent.config.attackDuraton)
            {
                timer = 0;

                //attacking = false;
                //agent.enemyAnimator.SetBool("Attacking", attacking);
                //attackArea.SetActive(false);

                if (agent.config.doesEnemyMove == true)
                {
                    AiHuntPlayerState huntState = agent.stateMachine.GetState(AiStateId.HuntPlayer) as AiHuntPlayerState;
                    agent.stateMachine.ChangeState(AiStateId.HuntPlayer);
                }
                else
                {
                    AiWanderingState wanderState = agent.stateMachine.GetState(AiStateId.Wander) as AiWanderingState;
                    agent.stateMachine.ChangeState(AiStateId.Wander);
                }
            }
        }

        //if (agent.config.doesEnemyMove == false)
        //{
        //    //left
        //    if (agent.playerTransform.position.x < agent.transform.localPosition.x)
        //    {
        //        agent.enemyAnimator.SetFloat("FacingRight", -1);
        //        agent.enemyAnimator.SetFloat("FacingUp", 0);
        //        agent.startWanderingLeft = true;
        //        //Debug.Log("Left");
        //    }
        //    else
        //    {
        //        agent.enemyAnimator.SetFloat("FacingRight", 1);
        //        agent.enemyAnimator.SetFloat("FacingUp", 0);
        //        agent.startWanderingLeft = false;
        //        //Debug.Log("Right");
        //    }
        //}

        agent.enemyAnimator.SetBool("Attacking", attacking);

    }

    public void Exit(AiAgent agent)
    {
        attacking = false;
        attackArea.SetActive(false);
        agent.enemyAnimator.SetBool("Attacking", false);

        if (agent.config.enemyIsBeetle == true)
        {
            stinger.SetActive(true);

        }
    }

}
