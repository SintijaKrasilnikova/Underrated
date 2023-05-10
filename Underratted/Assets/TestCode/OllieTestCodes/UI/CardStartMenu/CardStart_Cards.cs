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

    public AK.Wwise.Event cardEquip;

    public LoadoutPlayerStats healthStat;
    public LoadoutPlayerStats attackStat;
    public LoadoutPlayerStats speedStat;
    // Start is called before the first frame update
    void Start()
    {
        cardID = cardOver.loadoutCards[inventoryID];
        cardUse = cardOver.loadoutCardUse[inventoryID];
        cardRecharge = cardOver.loadoutCardRecharge[inventoryID];

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
        if (cardOver.loadoutCards.Count < inventoryID +1)
        {
            this.gameObject.SetActive(false);
        }
        cardImage.sprite = cardSprites[cardOver.loadoutCards[inventoryID]];

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
        if(cardUse != 0 && currentButton.GetComponent<CardStart_Buttons>().equippedID != inventoryID)
        {
            cardEquip.Post(gameObject);
            addStat();
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

    public void addStat()
    {
        switch (cardID)
        {
            case 0: //SPD+SPD Card
                {
                    speedStat.statNumb += 0.5f;
                    break;
                }
            case 1: //SPD+ATK Card
                {
                    speedStat.statNumb += 0.2f;
                    attackStat.statNumb += 0.5f;
                    break;
                }
            case 2: //SPD+HP Card
                {
                    speedStat.statNumb += 0.2f;
                    healthStat.statNumb += 1f;
                    break;
                }
            case 3: //ATK+ATK Card
                {
                    attackStat.statNumb += 1f;
                    break;
                }
            case 4: //ATK+HP Card
                {
                    attackStat.statNumb += 0.5f;
                    break;
                }
            case 5: //HP+HP Card
                {
                    healthStat.statNumb += 2f;
                    break;
                }
        }
    }
}
