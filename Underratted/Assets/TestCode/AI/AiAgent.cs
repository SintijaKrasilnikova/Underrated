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
    public Vector3 startPositionEnemy;

    public Transform playerTransform;

    public bool startWanderingLeft = true;
    
    //public bool facingLeft;



    // Start is called before the first frame update
    void Start()
    {
        startPositionEnemy = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        enemyAnimator.GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

        stateMachine = new AiStateMachine(this);

        stateMachine.RegisterState(new AiHuntPlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiAttackState());
        stateMachine.RegisterState(new AiWanderingState());
        //stateMachine.RegisterState(new AiHurtingState());
       
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();

    }
}
