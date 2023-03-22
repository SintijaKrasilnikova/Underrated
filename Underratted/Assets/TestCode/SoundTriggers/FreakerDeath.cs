using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreakerDeath : MonoBehaviour
{
    public AK.Wwise.Event freakerDeathSound;
    // Start is called before the first frame update
    void DeathSound()
    {
        freakerDeathSound.Post(gameObject);

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
