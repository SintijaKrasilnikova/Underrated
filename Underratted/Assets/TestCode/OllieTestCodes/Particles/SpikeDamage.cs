using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float extraDamage = 0;

    private AttackTimer baseAttackRef;
    public float baseDamage;
    public float damage;
    void Start()
    {
        baseAttackRef = this.GetComponent<AttackTimer>();
        damage = baseDamage + extraDamage;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("aaaa");
            baseDamage = baseAttackRef.GetBaseDamage();
            damage = baseDamage + extraDamage;

            var healthComp = other.gameObject.GetComponent<EnemyHealth>();
            if (healthComp != null)
            {
                //Debug.Log("Health decreased");
                healthComp.TakeDamage(damage);
                this.gameObject.SetActive(false);
            }
        }
    }
}
