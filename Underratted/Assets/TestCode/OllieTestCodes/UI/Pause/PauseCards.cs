using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCards : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public int cardID;
    public Sprite[] sprites;
    public Image cardImage;

    // Start is called before the first frame update
    void Start()
    {
        cardImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cardID > cardOver.fullCards.Count)
        {
            gameObject.SetActive(false);
        }
        else
        {
            cardImage.sprite = sprites[cardOver.fullCards[cardID]];
        }
    }
}
