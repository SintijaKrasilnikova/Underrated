using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CraftingNextScene : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public bool demoEnd = false;

    public GameObject creationAssets;
    public GameObject mixImage;
    public GameObject mixedCard;
    public EventSystem eventSystem;
    public NewCardSpawn newCardData;

    public GameObject playerCard;
    public GameObject leftCard;
    public GameObject rightCard;
    public GameObject middleCard;

    public MixAnim mixData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(cardOver.halfCards.Count > 0)
            {
                creationAssets.SetActive(true);
                playerCard.SetActive(true);
                leftCard.SetActive(true);
                rightCard.SetActive(true);
                middleCard.SetActive(true);
                mixData.canChangeCard = true;
                

                if (leftCard.GetComponent<CardRandom>().wasCrafted == false)
                {
                    eventSystem.SetSelectedGameObject(leftCard);
                }
                else
                {
                    eventSystem.SetSelectedGameObject(rightCard);
                }
                
                mixImage.SetActive(false);
                mixedCard.SetActive(false);
                newCardData.canRemoveListEle = true;
            }
        }

        if(cardOver.halfCards.Count <= 0)
        {
            if (demoEnd == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
