using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrail : MonoBehaviour
{
    public float trailDamage = 1;
    public float damageCoolDown = 2f;

    private float timer = 0;
    private bool isOnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (isOnCooldown)
        {
            if (timer > damageCoolDown)
            {
                isOnCooldown = false;
                timer = 0;
            }

            timer += Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //baseDamage = baseAttackRef.GetBaseDamage();
            //damage = baseDamage + extraDamage;

            if (isOnCooldown == false)
            {
                var healthComp = collision.GetComponent<EnemyHealth>();
                if (healthComp != null)
                {
                    isOnCooldown = true;
                    //Debug.Log("Health decreased");
                    healthComp.TakeDamage(trailDamage);
                    //this.gameObject.SetActive(false);
                }
            }
        }

    }

}
