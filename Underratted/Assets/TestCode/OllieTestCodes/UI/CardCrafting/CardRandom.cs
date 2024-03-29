using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardRandom : MonoBehaviour, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
    public int randomCard;
    public int cardValue;
    public Sprite speed;
    public Sprite attack;
    public Sprite health;
    public string buffDescRef;

    public bool isSelected;

    public GameObject playerPos;

    public int cardNumb;

    public Animator animator;

    public bool wasCrafted = false;

    public AK.Wwise.Event cardHighlight;

    public bool isMiddle;

    public void OnDeselect(BaseEventData eventData)
    {
        gameObject.tag = "Untagged";
        playerPos.tag = "Untagged";
    }

    public void OnSelect(BaseEventData eventData)
    {
        gameObject.tag = "UIActive";
        playerPos.tag = "UIActive";
        cardHighlight.Post(gameObject);
    }

    private void Awake()
    {
        //pick a random card to display on the screen
        randomCard = Random.Range(1, 4);
        var cardImage = gameObject.GetComponent<Image>();
        if(randomCard == 1)
        {
            cardImage.sprite = health;
            buffDescRef = "Max Health + 1";

            cardValue = 3;
        }
        if(randomCard == 2)
        {
            cardImage.sprite = attack;
            buffDescRef = "Attack + 0.5";
            cardValue = 2;
        }
        if(randomCard == 3)
        {
            cardImage.sprite = speed;
            buffDescRef = "Movement Speed + 0.5";
            cardValue = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wasCrafted)
        {
            gameObject.SetActive(false);
        }

        //animation plays when active and stops when inactive
        if(gameObject.tag == "UIActive")
        {
            animator.speed = 0.1f;
        }
        else if(gameObject.tag != "UIActive")
        {
            animator.speed = 0f;
        }
    }

    public void WasCrafted()
    {
        wasCrafted = true;
    }

    private void Start()
    {
        if (isMiddle)
        {
            gameObject.GetComponent<Button>().Select();
        }
    }
}
