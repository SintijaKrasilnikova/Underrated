using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
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
        foreach (CardStart_Buttons button in buttons)
        {
            if (button.isSelected)
            {
                currentButton = button.gameObject;
            }
        }

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
        if(hasBeenSelected == false)
        {
            currentButton.GetComponent<Image>().sprite = cardImage.sprite;
            currentButton.GetComponent<Button>().Select();
            hasBeenSelected = true;
        }
    }
}
