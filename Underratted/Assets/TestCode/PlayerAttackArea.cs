using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    public int damage = 3;

    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy"))
        {
           
            var healthComp = collision.GetComponent<EnemyHealth>();
            if(healthComp!=null)
            {
                //Debug.Log("Health decreased");
                healthComp.TakeDamage(damage);
            }
        }

    }
}
