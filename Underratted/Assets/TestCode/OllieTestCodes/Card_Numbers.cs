using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Numbers : MonoBehaviour
{
    public int speedCard = 0;
    public int attackCard = 0;
    public int healthCard = 0;

    public bool hasCard = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speedCard > 0)
        {
            hasCard = true;
        }
        if(attackCard > 0)
        {
            hasCard = true;
        }
        if(healthCard > 0)
        {
            hasCard = true;
        }
    }
}