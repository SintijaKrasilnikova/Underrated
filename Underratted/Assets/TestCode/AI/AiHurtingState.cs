using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHurtingState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Hurting;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("Hurting");
    }

    public void Exit(AiAgent agent)
    {
       
    }

    public void Update(AiAgent agent)
    {
       
    }
}
