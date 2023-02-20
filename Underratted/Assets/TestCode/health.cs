using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int maxHealth = 9;
    public int currentHealth;

    public Animator currentAnimator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //get the animator of gameObject
        currentAnimator = gameObject.GetComponent<Animator>(); 

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        //death check
        if( currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
