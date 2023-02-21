using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiState
{

    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("Attack");
    }

    public void Update(AiAgent agent)
    {

    }

    public void Exit(AiAgent agent)
    {
        
    }

}
