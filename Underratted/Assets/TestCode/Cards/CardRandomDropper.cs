using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardRandomDropper : MonoBehaviour
{

    //private bool spinAlreadyDropped = false;
    //public GameObject spinCardRef = default;

    public int dropChances;
    public string prefferdCardType;

    public SpinPickup spinRef = default;
    public CardCounter cardHistroyRef = default;

    public SpeedPickup speedRef = default;
    public HealthPickup healthRef = default;
    public AttackPickup attackRef = default;

    public AttackTimer attackTimer;

    public GameObject currentCardRef = default;

    //public bool spinUp = false;
    //public bool speedUp = false;
    //public bool healthUp = false;
    //public bool attackUp = false;


    private bool currentUp = false;


    void Start()
    {
    }


    // public void ChanceToDropCard(int dropChances, string cardType)
    public void ChanceToDropCard()
    {
        string cardType = prefferdCardType;
        if (cardType != "spin" && cardType != "speed" && cardType != "health" && cardType != "attack")
        {
            cardType = ChooseRandomCard();
        }
        //what card does enemy have a chance of dropping
        switch (cardType)
        {
            case "spin":
                {
                    currentCardRef = spinRef.gameObject;
                    spinRef.setSpinPickedUp(true);
                    currentUp = cardHistroyRef.GetSpinUp();
                    cardHistroyRef.SetSpinUp(true);
                    break;
                }
            case "speed":
                {
                    currentCardRef = speedRef.gameObject;
                    currentUp = cardHistroyRef.GetSpeedUp();
                    cardHistroyRef.SetSpeedUp(true);
                    break;
                }
            case "health":
                {
                    currentCardRef = healthRef.gameObject;
                    currentUp = cardHistroyRef.GetHealthUp();
                    cardHistroyRef.SetHealthUp(true);
                    break;
                }
            case "attack":
                {
                    currentCardRef = attackRef.gameObject;
                    currentUp = cardHistroyRef.GetAttackUp();
                    cardHistroyRef.SetAttackUp(true);
                    break;
                }

            //default: //invalid name has a chance of dropping any card

            //    currentCardRef = ChooseRandomCard();
            //    break;
        }

        //range from 1 to 100
        int randomChance = Random.Range(1, 100);


        if (randomChance < dropChances && currentUp == false)
        {
            //drop the card
            //spinRef.setSpinPickedUp(true);
            currentCardRef.transform.position = gameObject.transform.position;
            currentCardRef.SetActive(true);
            //attackTimer.setSpinActive(true);
        }


    }

    private string ChooseRandomCard()
    {
        int randomCard = Random.Range(0, 4);
        string chosenCardName = "";

        switch (randomCard)
        {
            case 0:
                {
                    chosenCardName = "spin";
                    break;
                }
            case 1:
                {
                    chosenCardName = "speed";
                    break;
                }
            case 2:
                {
                    chosenCardName = "health";
                    break;
                }
            case 3:
                {
                    chosenCardName = "attack";
                    break;
                }
        }

        return chosenCardName;
    }

    //private GameObject ChooseRandomCard()
    //{
    //    int randomCard = Random.Range(0, 3);
    //    GameObject chosenCard = speedRef.gameObject;

    //    switch (randomCard)
    //    {
    //        case 0:
    //            {
    //                chosenCard = spinRef.gameObject;
    //                break;
    //            }
    //        case 1:
    //            {
    //                chosenCard = speedRef.gameObject;
    //                break;
    //            }
    //        case 2:
    //            {
    //                chosenCard = healthRef.gameObject;
    //                break;
    //            }
    //        case 3:
    //            {
    //                chosenCard = attackRef.gameObject;
    //                break;
    //            }
    //    }

    //    return chosenCard;
    //}
}
