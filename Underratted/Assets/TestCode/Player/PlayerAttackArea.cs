using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    public float extraDamage = 0;

    private AttackTimer baseAttackRef;
    private float baseDamage;
    private float damage;
    void Start()
    {
        baseAttackRef = this.GetComponentInParent<AttackTimer>();
        baseDamage = baseAttackRef.GetBaseDamage();
        damage = baseDamage + extraDamage;
    }
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            baseDamage = baseAttackRef.GetBaseDamage();
            damage = baseDamage + extraDamage;

            var healthComp = collision.GetComponent<EnemyHealth>();
            if(healthComp!=null)
            {
                //Debug.Log("Health decreased");
                healthComp.TakeDamage(damage);
                this.gameObject.SetActive(false);
            }
        }

    }
}
