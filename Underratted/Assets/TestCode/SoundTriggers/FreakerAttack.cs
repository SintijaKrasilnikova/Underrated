using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreakerAttack : MonoBehaviour
{
    public AK.Wwise.Event freakerAttackSound;
    // Start is called before the first frame update
    void AttackSound()
    {
        freakerAttackSound.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
