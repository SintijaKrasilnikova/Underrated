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
        
    }

    private void Awake()
    {
        int indexElement;
        var currentSprite = gameObject.GetComponent<Image>();

        //pick a random card from the list the player has
        indexElement = Random.Range(0, cardOver.fullCards.Count);
        cardID = cardOver.fullCards[indexElement];

        //remove element from list
        cardOver.fullCards.RemoveAt(indexElement);

        //change card sprite to be the right card
        currentSprite.sprite = cardSprites[cardID];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
