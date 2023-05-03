using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PauseCards : MonoBehaviour, IEventSystemHandler, ISelectHandler
{
    [SerializeField] private CardOverseer cardOver;

    public int cardID;
    public Sprite[] sprites;
    public Image cardImage;

    public TextMeshProUGUI buff1TMP;
    public TextMeshProUGUI buff2TMP;
    public TextMeshProUGUI abilityTMP;

    public string[] buff1Text;
    public string[] buff2Text;
    public string[] abilityText;

    public Button self;
    // Start is called before the first frame update
    void Start()
    {
        cardImage = this.GetComponent<Image>();
        self = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cardID > cardOver.fullCards.Count -1)
        {
            cardImage.enabled = false;
            self.enabled = false;
        }
        else
        {
            cardImage.enabled = true;
            self.enabled = true;
            cardImage.sprite = sprites[cardOver.fullCards[cardID]];
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        buff1TMP.text = buff1Text[cardOver.fullCards[cardID]];
        buff2TMP.text = buff2Text[cardOver.fullCards[cardID]];
        abilityTMP.text = abilityText[cardOver.fullCards[cardID]];
    }
}
