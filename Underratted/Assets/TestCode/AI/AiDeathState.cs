using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{

    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(AiAgent agent)
    {
        Debug.Log("Died");
    }

    public void Update(AiAgent agent)
    {
        agent.gameObject.SetActive(false);
       
    }

    public void Exit(AiAgent agent)
    {

        //agent.gameObject.SetActive(false);
    }
}
