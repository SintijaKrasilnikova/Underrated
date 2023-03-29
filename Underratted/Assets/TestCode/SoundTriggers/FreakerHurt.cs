using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreakerHurt : MonoBehaviour
{
    public AK.Wwise.Event freakerHurtSound;
    // Start is called before the first frame update
    void HurtSound()
    {
        freakerHurtSound.Post(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
