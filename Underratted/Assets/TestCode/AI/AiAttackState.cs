using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiAttackState : AiState
{
    private bool attacking = false;
    private float timeToAttack = 0.9f;
    
    private float timer = 0f;
    private GameObject attackArea = default;
    private bool areaActive = false;

    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }

    public void Enter(AiAgent agent)
    {
        //Debug.Log("Attack");

        attacking = true;
        agent.readyToAttack = false;

        timer = 0f;
        areaActive = false;

        if (agent.transform.GetChild(0).gameObject.tag == "AttackArea")
        {
            attackArea = agent.transform.GetChild(0).gameObject;
            
        }
        else
        {
            Debug.Log("Attack area not found!");
        }

         //attackArea = agent.transform.GetComponentInChildren<BoxCollider>();
    }

    public void Update(AiAgent agent)
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if( timer > agent.config.attackPrepare && areaActive == false)
            {
                areaActive = true;
                attackArea.SetActive(true);
                //Debug.Log(timer);

            }
           

            if (timer >= timeToAttack)
            {
                timer = 0;

                attacking = false;
                agent.enemyAnimator.SetBool("Attacking", attacking);
                attackArea.SetActive(false);

                AiHuntPlayerState huntState = agent.stateMachine.GetState(AiStateId.HuntPlayer) as AiHuntPlayerState;
                agent.stateMachine.ChangeState(AiStateId.HuntPlayer);
            }
        }

        agent.enemyAnimator.SetBool("Attacking", attacking);

    }

    public void Exit(AiAgent agent)
    {
        //GameObject.FindGameObjectWithTag("Player");
    }

}
