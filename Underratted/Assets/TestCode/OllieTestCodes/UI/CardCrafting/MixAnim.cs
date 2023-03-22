using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixAnim : MonoBehaviour
{
    public Animator playerCard;
    public GameObject uiCard;
    Animator uiCardAnim;

    public GameObject leftCard;
    public GameObject rightCard;
    public GameObject middleCard;

    //new card spawned at end of animation
    public GameObject newCard;
    private bool canChangeCard = true;
    public bool canLoadNextLevel = false;
    public GameObject continueMsg;

   
    // Start is called before the first frame update
    void Start()
    {
        canLoadNextLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canChangeCard)
        {
            uiCard = GameObject.FindGameObjectWithTag("UIActive");
            uiCardAnim = uiCard.GetComponent<Animator>();
        }
    }

    public void Mix()
    {
        playerCard.SetBool("Mix", true);
        uiCardAnim.SetBool("Mix", true);
        canChangeCard = false;
    }

    public void HideMiddleCard()
    {
        middleCard.SetActive(false);
    }
    public void HideLeftCard()
    {
        leftCard.SetActive(false);
    }
    public void HideRightCard()
    {
        rightCard.SetActive(false);
    }
    public void HidePlayerCard()
    {
        gameObject.SetActive(false);
    }

    //combines the two halves
    public void MakeNewCard()
    {
        continueMsg.SetActive(true);
        canLoadNextLevel = true;
        newCard.SetActive(true);
        Debug.Log("Mix");
    }

}
