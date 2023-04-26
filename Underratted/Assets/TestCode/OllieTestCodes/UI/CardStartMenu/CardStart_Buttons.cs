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
    public AK.Wwise.Event cardEquipSound;

    public Outline outline;
    public bool isPassive = false;
    public int equippedID;
    public CardStartDescriptions descriptionRef;
    public void OnDeselect(BaseEventData eventData)
    {
        //outline.enabled = false;
        isSelected = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        //outline.enabled = true;
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
        //outline = this.GetComponent<Outline>();
        //outline.enabled = false;
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
                cardEquipSound.Post(gameObject);
            }
        }

        if (hasCard)
        {
            equippedID = selectedCard.cardID;
        }
    }

    public void buttonClicked()
    {
        nextToSelect.GetComponent<Button>().Select();
        isSelected = true;
    }
}
