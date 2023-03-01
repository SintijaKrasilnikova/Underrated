using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Enemy")
        {
           
            var healthComp = collision.GetComponent<Health>();
            if(healthComp!=null)
            {
                //Debug.Log("Health decreased");
                healthComp.TakeDamage(damage);
            }
        }

    }
}
