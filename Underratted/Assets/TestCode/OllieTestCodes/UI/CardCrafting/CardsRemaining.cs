using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsRemaining : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public GameObject remaining1;
    public GameObject remaining2;

    public Sprite[] cardSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cardOver.halfCards.Count <= 1)
        {
            remaining1.SetActive(false);
            remaining2.SetActive(false);
        }

        if(cardOver.halfCards.Count == 2)
        {
            remaining1.SetActive(true);
            remaining1.GetComponent<Image>().sprite = cardSprite[cardOver.halfCards[1]];

            remaining2.SetActive(false);
        }

        if (cardOver.halfCards.Count == 3)
        {
            remaining1.SetActive(true);
            remaining1.GetComponent<Image>().sprite = cardSprite[cardOver.halfCards[1]];

            remaining2.SetActive(true);
            remaining2.GetComponent<Image>().sprite = cardSprite[cardOver.halfCards[2]];
        }
    }
}
