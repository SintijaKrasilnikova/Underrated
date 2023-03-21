using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDescriptions : MonoBehaviour
{
    //ref to the cards to get their text
    public GameObject buff1Text;
    public GameObject buff2Text;
    public GameObject abilityBonusText;

    //ref to edit the text of the cards
    public string buff1Desc;
    public string buff2Desc;
    public string abilityBonusDesc;

    //ref to get the card's text components
    TextMeshProUGUI buff1TMP;
    TextMeshProUGUI buff2TMP;
    TextMeshProUGUI abilityBonusTMP;

    //ref of the cards to see which one is selected
    public GameObject activeCard;

    public GameObject playerCard;
    public CardAbilityNames abilityRef;
    // Start is called before the first frame update
    void Start()
    {
        //get the text components
        buff1TMP = buff1Text.GetComponent<TextMeshProUGUI>();
        buff2TMP = buff2Text.GetComponent<TextMeshProUGUI>();
        abilityBonusTMP = abilityBonusText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //replace the buff description with the currently active ui card
        activeCard = GameObject.FindGameObjectWithTag("UIActive");
        activeCard.GetComponent<CardRandom>();
        buff2TMP.text = activeCard.GetComponent<CardRandom>().buffDescRef;

        //replace the buff description with the currently active player card
        playerCard = GameObject.FindGameObjectWithTag("PlayerCard");
        playerCard.GetComponent<SelectingCard>();
        buff1TMP.text = playerCard.GetComponent<SelectingCard>().buffText;


        //abilityBonusTMP.text = gameObject.GetComponent<CardAbilityNames>().abilityNames[gameObject.GetComponent<CardAbilityNames>().abilityNumb];
        abilityBonusTMP.text = abilityRef.abilityNames[abilityRef.abilityNumb];

    }
}
