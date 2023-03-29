using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbilityNames : MonoBehaviour
{
    public GameObject playerCard;
    public GameObject uiCard;
    public int abilityNumb;
    public string[] abilityNames;
    public Sprite[] abilities;

    //[SerializeField] private CardOverseer cardOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiCard = GameObject.FindGameObjectWithTag("UIActive");
        //abilityNumb = playerCard.GetComponent<SelectingCard>().playerCardNumber 
        //    + uiCard.GetComponent<CardRandom>().cardValue;

        switch (playerCard.GetComponent<SelectingCard>().playerCardNumber)
        {
            case 1://player has the speed half
                {

                    switch (uiCard.GetComponent<CardRandom>().cardValue)
                    {
                        case 1:
                            { //the other card is speed
                                
                                abilityNumb = 1;
                                break;
                            }
                        case 2://attack
                            { 

                                abilityNumb = 2;
                                break;
                            }
                        case 3://health
                            {

                                abilityNumb = 3;
                                break;
                            }
                    }
                    break;
                }

            case 2://player has the attack half
                {

                    switch (uiCard.GetComponent<CardRandom>().cardValue)
                    {
                        case 1:
                            { //the other car is speed

                                abilityNumb = 2;
                                break;
                            }
                        case 2://attack
                            {

                                abilityNumb = 4;
                                break;
                            }
                        case 3://health
                            {

                                abilityNumb = 5;
                                break;
                            }
                    }
                    break;
                }

            case 3://player has the health half
                {

                    switch (uiCard.GetComponent<CardRandom>().cardValue)
                    {
                        case 1:
                            { //the other car is speed

                                abilityNumb = 3;
                                break;
                            }
                        case 2://attack
                            {

                                abilityNumb = 5;
                                break;
                            }
                        case 3://health
                            {

                                abilityNumb = 6;
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public int GetAbilityNumber()
    {
        return abilityNumb;
    }
}
