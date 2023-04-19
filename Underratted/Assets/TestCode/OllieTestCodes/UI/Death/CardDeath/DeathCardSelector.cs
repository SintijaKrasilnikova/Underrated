using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCardSelector : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public int cardID;
    public Sprite[] cardSprites;
    // Start is called before the first frame update
    void Start()
    {
        int indexElement;
        var currentSprite = gameObject.GetComponent<Image>();

        //pick a random card from the list the player has
        indexElement = Random.Range(2, cardOver.fullCards.Count - 1);
        cardID = cardOver.fullCards[indexElement];

        //remove element from list
        cardOver.fullCards.RemoveAt(indexElement);

        //change card sprite to be the right card
        currentSprite.sprite = cardSprites[cardID];


    }

    private void Awake()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (cardID == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
