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
    public bool isRecharging = false;

    public TextMeshProUGUI useText;

    public GameObject rechargeBar;
    public GameObject useRef;
    // Start is called before the first frame update
    void Start()
    {
        cardUse = cardOver.loadoutCardUse[cardID];
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

        cardID = cardOver.loadoutCards[inventoryID];
        if(cardID == 0)
        {
            this.gameObject.SetActive(false);
        }
        cardImage.sprite = cardSprites[cardID];
    }

    // Update is called once per frame
    void Update()
    {
        if (cardOver.loadoutCardRecharge[cardID] > 1)
        {
            cardOver.loadoutCardRecharge[cardID] = 1;
        }

        foreach (CardStart_Buttons button in buttons)
        {
            if (button.isSelected)
            {
                currentButton = button.gameObject;
            }
        }

        if(cardUse != 0)
        {
            cross.SetActive(false);
        }
        else
        {
            cross.SetActive(true);
        }

        useText.text = cardUse.ToString();

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
            currentButton.GetComponent<Image>().sprite = cardImage.sprite;
            currentButton.GetComponent<Button>().Select();
            currentButton.GetComponent<CardStart_Buttons>().hasCard = true;
            currentButton.GetComponent<CardStart_Buttons>().selectedCard = this;
            cardUse--;
        }
    }
}
