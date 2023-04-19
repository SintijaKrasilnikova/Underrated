using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCardHandler : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public GameObject half1;
    public GameObject half2;
    public GameObject half3;

    public Sprite[] halfSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(cardOver.halfCards.Count + 1 == half3.GetComponent<CollectedHalfCard>().cardRef)
        //{
        //    half3.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half3.GetComponent<CollectedHalfCard>().cardRef];
        //    half3.SetActive(true);
        //    half3.GetComponent<Image>().sprite = halfSprites[half3.GetComponent<CollectedHalfCard>().cardID];
        //}
        //if (cardOver.halfCards.Count -1 == half2.GetComponent<CollectedHalfCard>().cardRef)
        //{
        //    half2.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half2.GetComponent<CollectedHalfCard>().cardRef];
        //    half2.SetActive(true);
        //    half2.GetComponent<Image>().sprite = halfSprites[half2.GetComponent<CollectedHalfCard>().cardID];
        //}
        //if (cardOver.halfCards.Count -1 == half1.GetComponent<CollectedHalfCard>().cardRef)
        //{
        //    half1.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half1.GetComponent<CollectedHalfCard>().cardRef];
        //    half1.SetActive(true);
        //    half1.GetComponent<Image>().sprite = halfSprites[half1.GetComponent<CollectedHalfCard>().cardID];
        //}

        if(cardOver.halfCards.Count == 3)
        {
            half3.SetActive(true);
            half3.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half3.GetComponent<CollectedHalfCard>().cardRef];
            half3.GetComponent<Image>().sprite = halfSprites[half3.GetComponent<CollectedHalfCard>().cardID];

            half2.SetActive(true);
            half2.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half2.GetComponent<CollectedHalfCard>().cardRef];
            half2.GetComponent<Image>().sprite = halfSprites[half2.GetComponent<CollectedHalfCard>().cardID];

            half1.SetActive(true);
            half1.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half1.GetComponent<CollectedHalfCard>().cardRef];
            half1.GetComponent<Image>().sprite = halfSprites[half1.GetComponent<CollectedHalfCard>().cardID];
        }
        if(cardOver.halfCards.Count == 2)
        {
            half3.SetActive(false);

            half2.SetActive(true);
            half2.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half2.GetComponent<CollectedHalfCard>().cardRef];
            half2.GetComponent<Image>().sprite = halfSprites[half2.GetComponent<CollectedHalfCard>().cardID];

            half1.SetActive(true);
            half1.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half1.GetComponent<CollectedHalfCard>().cardRef];
            half1.GetComponent<Image>().sprite = halfSprites[half1.GetComponent<CollectedHalfCard>().cardID];
        }
        if(cardOver.halfCards.Count == 1)
        {
            half3.SetActive(false);

            half2.SetActive(false);

            half1.SetActive(true);
            half1.GetComponent<CollectedHalfCard>().cardID = cardOver.halfCards[half1.GetComponent<CollectedHalfCard>().cardRef];
            half1.GetComponent<Image>().sprite = halfSprites[half1.GetComponent<CollectedHalfCard>().cardID];
        }

    }
}
