using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalAttackArea : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Enemy")
        {
           
            var healthComp = collision.GetComponent<health>();
            if(healthComp!=null)
            {
                Debug.Log("Health decreased");
                healthComp.TakeDamage(damage);
            }
        }

    }
}
