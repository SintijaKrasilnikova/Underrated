using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardStart_Cards : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public CardStart_Buttons[] buttons;
    public GameObject currentButton;
    public bool hasBeenSelected = false;
    public Image cardImage;
    public GameObject cross;

    public int cardID;
    public Sprite[] cardSprites;

    public int inventoryID;

    public int cardUse;
    public float cardRecharge;
    public bool isRecharging = false;

    public TextMeshProUGUI useText;

    public GameObject rechargeBar;
    public GameObject useRef;
    // Start is called before the first frame update
    void Start()
    {
        cardUse = cardOver.loadoutCardUse[cardID];
        cardRecharge = cardOver.loadoutCardRecharge[cardID];

        if(cardUse <= 0)
        {
            isRecharging = true;
            rechargeBar.SetActive(true);
            hasBeenSelected = true;
            useRef.SetActive(false);
        }
        else
        {
            isRecharging = false;
            rechargeBar.SetActive(false);
            hasBeenSelected = false;
        }

        if (cardRecharge > 1.0f)
        {
            isRecharging = false;
            rechargeBar.SetActive(false);
            hasBeenSelected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cardOver.loadoutCards.Count < cardID +1)
        {
            this.gameObject.SetActive(false);
        }
        cardImage.sprite = cardSprites[cardOver.loadoutCards[cardID]];

        //see all selected buttons in scene
        foreach (CardStart_Buttons button in buttons)
        {
            if (button.isSelected)
            {
                currentButton = button.gameObject;
            }
        }

        //cross enabled when no cards left to show cant equip more
        if(cardUse != 0)
        {
            cross.SetActive(false);
        }
        else
        {
            cross.SetActive(true);
        }

        useText.text = "X" + cardUse.ToString();

        //if (hasBeenSelected)
        {
            //cross.SetActive(true);
        }
        //else
        {
            //cross.SetActive(false);
        }

    }

    public void cardSelected()
    {
        if(cardUse != 0)
        {
            currentButton.GetComponent<CardStart_Buttons>().hasCard = true;
            currentButton.GetComponent<CardStart_Buttons>().equippedID = cardID;
            currentButton.GetComponent<CardStartDescriptions>().cardEquipped();
            currentButton.GetComponent<Image>().sprite = cardImage.sprite;
            currentButton.GetComponent<Button>().Select();
            currentButton.GetComponent<CardStart_Buttons>().hasCard = true;
            currentButton.GetComponent<CardStart_Buttons>().selectedCard = this;
            cardUse--;
        }
    }
}
