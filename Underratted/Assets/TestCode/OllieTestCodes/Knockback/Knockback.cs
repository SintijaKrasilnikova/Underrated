using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    public PlayerMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(knockBackCounter <= 0)
        {
            knockBackCounter -= Time.deltaTime;
        }
        else
        {
            knockBackCounter = 0;
        }
    }

    public void KnockbackStart(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        direction = new Vector3(1f, 1f, 1f);

        if(gameObject.CompareTag("Player"))
        {
            movement.playerMovementInput = direction * knockBackForce;
        }
    }
}
