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
        for (int i = 0; i < cardOver.fullCards.Count; i++)
        {
            switch (cardOver.fullCards[i])
            {
                case 1:
                    {
                        playerMovement.AddSpeed(1.5f);
                        break;
                    }
                case 2:
                    {
                        playerMovement.AddSpeed(1f);
                        attack.IncreaseBaseDamage(0.5f);
                        break;
                    }
                case 3:
                    {
                        attack.ChangeRestTime();

                        playerHealth.IncreaseMaxHealth(1);
                        playerMovement.AddSpeed(1f);
                        break;
                    }
                case 4:
                    {
                        attack.IncreaseCritChance(5);
                        break;
                    }
                case 5:
                    {
                        attack.IncreaseBaseDamage(0.5f);
                        playerHealth.IncreaseMaxHealth(1);

                        playerHealth.IncreaseHealthSteal(5);
                        break;
                    }
                case 6:
                    {
                        playerHealth.IncreaseMaxHealth(2);
                        playerHealth.IncreaseHealthPickupRate();

                        break;
                    }
            }
        }
        //if (cardOver.SpeedSpeed == true)
        //{
        //    //for(int i = 0; i < cardOver.fullCards.Count; i++)
        //    //{
        //    //    if (cardOver.fullCards[i] == 1)
        //    //    {
        //    //        playerMovement.AddSpeed(1.5f);
        //    //    }
        //    //}
        //    //constant increased speed
        //    //playerMovement.SpeedUp();

        //    //playerMovement.AddSpeed(1.5f);

        //}
        if (cardOver.AttackSpeed == true)
        {
            //damage trail
            attack.SetTrailAreaActive();


        }
        //if (cardOver.HealthSpeed == true)
        //{
        //    ////increases time between attacks
        //    //attack.ChangeRestTime();

        //    //playerMovement.AddSpeed(1f);

        //}
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

        //if (cardOver.HealthHealth == true)
        //{
        //    //increases health droprates
        //    //playerHealth.IncreaseHealthPickupRate();

        //}

        if(cardOver.DodgeActive == true)
        {
            playerMovement.SetDodgeIsAvailable();
        }

    }

  
}
