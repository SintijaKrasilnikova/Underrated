using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTest : MonoBehaviour
{
    public float KnockbackForce = 500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Knockback()
    {
        transform.position -= transform.forward * Time.deltaTime * KnockbackForce;
    }
}
