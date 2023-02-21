using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navAgent;

    public AiAgentConfig config;
    public Animator enemyAnimator;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator.GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

        stateMachine = new AiStateMachine(this);

        stateMachine.RegisterState(new AiHuntPlayerState());
        stateMachine.RegisterState(new AiAttackState());
        //stateMachine.RegisterState(new AiDeathState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
