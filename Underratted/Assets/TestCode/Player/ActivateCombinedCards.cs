using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCombinedCards : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private AttackTimer attack;
    [SerializeField] private PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        if (cardOver.SpeedSpeed == true)
        {
            //constant increased speed
            playerMovement.SpeedUp();

        }
        if (cardOver.AttackSpeed == true)
        {
            //damage trail
            //attack.SetTrailAreaActive();
        }
        if (cardOver.HealthSpeed == true)
        {
            //increases time between attacks
            attack.ChangeRestTime();

        }
        if (cardOver.AttackAttack == true)
        {
            //Activates a chance to crit
            attack.SetCritPossibleActive();

        }
        if (cardOver.HealthAttack == true)
        {
            //Activates a chance to lifesteal
            playerHealth.SetLifestealActive();

        }

        if (cardOver.HealthHealth == true)
        {
            //increases health droprates

        }

    }

  
}
