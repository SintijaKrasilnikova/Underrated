using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleAttackArea : MonoBehaviour
{
    public int beetleDamage = 2;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {

            var healthComp = collision.GetComponent<health>();
            if (healthComp != null)
            {
                Debug.Log("Health decreased");
                healthComp.TakeDamage(beetleDamage);
            }
        }

    }
}
