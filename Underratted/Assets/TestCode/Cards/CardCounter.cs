using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCounter : MonoBehaviour
{
    public static bool spinUp = false;
    public static bool speedUp = false;
    public static bool healthUp = false;
    public static bool attackUp = false;
    
   

    //spin attack
    public bool GetSpinUp()
    {
        return spinUp;
    }
    public void SetSpinUp(bool isActivated)
    {
        spinUp = isActivated;
    }

    //speed
    public bool GetSpeedUp()
    {
        return speedUp;
    }
    public void SetSpeedUp(bool isActivated)
    {
        speedUp = isActivated;
    }

    //health
    public bool GetHealthUp()
    {
        return healthUp;
    }
    public void SetHealthUp(bool isActivated)
    {
        healthUp = isActivated;
    }

    //attack base damage
    public bool GetAttackUp()
    {
        return attackUp;
    }
    public void SetAttackUp(bool isActivated)
    {
        attackUp = isActivated;
    }
}
