using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrail : MonoBehaviour
{
    public int trailDamage = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //baseDamage = baseAttackRef.GetBaseDamage();
            //damage = baseDamage + extraDamage;

            var healthComp = collision.GetComponent<EnemyHealth>();
            if (healthComp != null)
            {
                //Debug.Log("Health decreased");
                healthComp.TakeDamage(trailDamage);
                //this.gameObject.SetActive(false);
            }
        }

    }

}
