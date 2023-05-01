using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardStartDescriptions : MonoBehaviour, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private CardOverseer cardOver;

    public TextMeshProUGUI buff1TMP;
    public TextMeshProUGUI buff2TMP;
    public TextMeshProUGUI Ability;

    public string[] buff1Text;
    public string[] buff2Text;
    public string[] abilityText;
    public string noEquipText;

    public bool isEquip = false;
    public CardStart_Buttons equipRef;
    public void OnDeselect(BaseEventData eventData)
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        //if (isEquip)
        //{
        //    if(equipRef.hasCard == false)
        //    {
        //        buff1TMP.text = noEquipText;
        //    }
        //}

        if (isEquip)
        {
            if (equipRef.hasCard == false)
            {
                buff1TMP.text = noEquipText;
                buff2TMP.text = "";
                Ability.text = "";
            }
            else
            {
                buff1TMP.text = buff1Text[equipRef.equippedID];
                buff2TMP.text = buff2Text[equipRef.equippedID];
                Ability.text = abilityText[equipRef.equippedID];
            }
        }

        if(isEquip == false)
        {
            buff1TMP.text = buff1Text[this.GetComponent<CardStart_Cards>().cardID];
            buff2TMP.text = buff2Text[this.GetComponent<CardStart_Cards>().cardID];
            Ability.text = abilityText[this.GetComponent<CardStart_Cards>().cardID];
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        equipRef = this.GetComponent<CardStart_Buttons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cardEquipped()
    {
        buff1TMP.text = buff1Text[equipRef.equippedID];
        buff2TMP.text = buff2Text[equipRef.equippedID];
        Ability.text = abilityText[equipRef.equippedID];
    }
}
