using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardStart_Buttons : MonoBehaviour, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
    public GameObject skillMenu;
    public GameObject passiveMenu;
    public bool isSelected = false;
    public GameObject nextToSelect;
    public Sprite baseSprite;
    public Image buttonImage;
    public bool hasCard = false;
    public CardStart_Cards selectedCard;
    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;

        if (gameObject.tag == "SkillButton")
        {
            skillMenu.SetActive(true);
            passiveMenu.SetActive(false);
        }
        if (gameObject.tag == "PassiveButton")
        {
            skillMenu.SetActive(false);
            passiveMenu.SetActive(true);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected && hasCard)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                buttonImage.sprite = baseSprite;
                selectedCard.cardUse++;
                selectedCard = null;
            }
        }

    }

    public void buttonClicked()
    {
        nextToSelect.GetComponent<Button>().Select();
        isSelected = true;
    }
}
