using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AiAgentConfig : ScriptableObject
{
    public bool doesEnemyMove = true;
   // public bool startsFacingRight = true;

    public float huntingDistance = 5f;
    public float huntingStopDistance = 5f;

    public Vector3 wanderDistance = new Vector3(3,0,3);

    public float attackCooldown = 3f;
    public float attackPrepare = 0.5f;
    public float attackDuraton = 0.9f;

    public bool enemyIsBeetle = false;
    public float chargeSpeedIncrease = 6f;
    public bool startWanderingLeft = true;

    //public Vector3 dangerDistance = new Vector3(0, 0, 0);
}
