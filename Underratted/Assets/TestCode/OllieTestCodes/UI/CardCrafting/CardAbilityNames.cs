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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiCard = GameObject.FindGameObjectWithTag("UIActive");
        abilityNumb = playerCard.GetComponent<SelectingCard>().playerCardNumber 
            + uiCard.GetComponent<CardRandom>().cardValue;
    }
}
