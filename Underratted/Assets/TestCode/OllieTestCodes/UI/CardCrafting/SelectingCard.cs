using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectingCard : MonoBehaviour
{
    public GameObject moveRef;
    public CardRandom cardRef;
    public Vector2 currentPos;
    public Vector2 MoveTowards;

    public Card_Numbers cardNumber;

    public Sprite speed;
    public Sprite attack;
    public Sprite health;
    public string buffText;

    public Animator animator;

    //ref for ability descriptions
    public int playerCardNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        var selectImage = gameObject.GetComponent<Image>();
        if (cardNumber.speedCard > 0)
        {
            selectImage.sprite = speed;
            buffText = "Speed +1";
            playerCardNumber = 1;
        }
        else if(cardNumber.attackCard > 0)
        {
            selectImage.sprite = attack;
            buffText = "Attack +1";
            playerCardNumber = 2;
        }
        else if(cardNumber.healthCard > 0)
        {
            selectImage.sprite = health;
            buffText = "Health +1";
            playerCardNumber = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //find the active ui card and set it as the move ref
        moveRef = GameObject.FindGameObjectWithTag("UIActive");
        moveRef.GetComponent<CardRandom>();
        //this can maybe go since its using animation now
        MoveTowards = new Vector2(moveRef.GetComponent<CardRandom>().playerPos.transform.position.x, moveRef.GetComponent<CardRandom>().playerPos.transform.position.y);
        transform.LeanMoveLocal(new Vector2(MoveTowards.x, MoveTowards.y), 0);

        //trigger animation based on the currently active card
        if(moveRef.GetComponent<CardRandom>().cardNumb == 1)
        {
            animator.SetBool("MiddleIdle", true);
            animator.SetBool("LeftIdle", false);
            animator.SetBool("RightIdle", false);
        }
        if (moveRef.GetComponent<CardRandom>().cardNumb == 2)
        {
            animator.SetBool("MiddleIdle", false);
            animator.SetBool("LeftIdle", true);
            animator.SetBool("RightIdle", false);
        }
        if (moveRef.GetComponent<CardRandom>().cardNumb == 3)
        {
            animator.SetBool("MiddleIdle", false);
            animator.SetBool("LeftIdle", false);
            animator.SetBool("RightIdle", true);
        }

    }
}
