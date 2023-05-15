using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DeathCardSelector : MonoBehaviour, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private CardOverseer cardOver;
    public int cardID;
    public Sprite[] cardSprites;
    public EventSystem eventSystem;

    public GameObject firstToBeSelected;
    public Button firstButton;

    public TextMeshProUGUI buff1TMP;
    public TextMeshProUGUI buff2TMP;
    public TextMeshProUGUI abilityTMP;

    public string[] buff1Text;
    public string[] buff2Text;
    public string[] abilityText;

    public bool isMiddleCard = false;
    public bool isRightCard = false;

    public int finalCardCount;

    public GameObject leftCard;
    public GameObject rightCard;

    public GameObject noCardScreen;
    public GameObject saveAssets;
    public bool isMiddle = false;
    // Start is called before the first frame update
    void Start()
    {

        finalCardCount = cardOver.fullCards.Count;



        if(finalCardCount == cardOver.cardsEquippedInLoadout)
        {
            if (noCardScreen.GetComponent<NoCardRetunToTitle>().isSet == false)
            {
                
                noCardScreen.SetActive(true);
                saveAssets.SetActive(false);
            }
        }



        int indexElement;
        var currentSprite = gameObject.GetComponent<Image>();


        //pick a random card from the list the player has
        indexElement = Random.Range(cardOver.cardsEquippedInLoadout, cardOver.fullCards.Count - 1);
        cardID = cardOver.fullCards[indexElement] +1;


        //remove element from list
        cardOver.fullCards.RemoveAt(indexElement);

        //change card sprite to be the right card
        currentSprite.sprite = cardSprites[cardID];

        eventSystem.firstSelectedGameObject = firstToBeSelected;
        firstButton.Select();

        if (isMiddle)
        {
            buff1TMP.text = buff1Text[cardID];
            buff2TMP.text = buff2Text[cardID];
            abilityTMP.text = abilityText[cardID];
        }

        

    }

    private void Awake()
    {


    }

    // Update is called once per frame
    void Update()
    {
        IDCheck();
    }

    public void IDCheck()
    {
        if (cardID == 0)
        {
            gameObject.SetActive(false);
        }
    }


    public void OnDeselect(BaseEventData eventData)
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        buff1TMP.text = buff1Text[cardID];
        buff2TMP.text = buff2Text[cardID];
        abilityTMP.text = abilityText[cardID];
    }

    public void firstCardSlideIn()
    {
        cardOver.rechargeCards();
        noCardScreen.GetComponent<NoCardRetunToTitle>().isSet = true;
        if(finalCardCount > cardOver.cardsEquippedInLoadout)
        {
            leftCard.SetActive(true);
        }
        else
        {
            eventSystem.firstSelectedGameObject = firstToBeSelected;
            firstButton.Select();
        }
    }

    public void leftSlideIn()
    {
        if (finalCardCount > cardOver.cardsEquippedInLoadout)
        {
            rightCard.SetActive(true);
        }
        else
        {
            eventSystem.firstSelectedGameObject = firstToBeSelected;
            firstButton.Select();
        }
    }

    public void rightSlideIn()
    {
        eventSystem.firstSelectedGameObject = firstToBeSelected;
        firstButton.Select();
    }
}
