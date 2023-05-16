using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PortalEnd : MonoBehaviour
{

    private int LoadNextLevel;
    public GameObject endScreen;
    public Card_Numbers playerRef;
    public PlayerMovement playerMove;
    public GameObject lulu;
    public AK.Wwise.Event endLevelSound;
    public GameObject cardholder;

    public bool isAlphaPortal = false;
    private PlayerHealth health;
    public CardOverseer overSeer;

    public GameObject dodgeUnlockScreen;
    public GameObject noCardPieces;

    public GameObject endVideo;
    public VideoPlayer endVideoData;
    public bool playVideo = false;

    public bool noCards = false;
    public bool endScrrenActivated = false;

    public EventSystem eventSystem;
    public GameObject cardButton;

    // Start is called before the first frame update
    void Start()
    {
        health = playerRef.GetComponent<PlayerHealth>();
        playerMove = playerRef.GetComponent<PlayerMovement>();
        //overSeer = playerRef.GetComponent<CardOverseer>();
        //noCards = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(endScrrenActivated)
        {
            playerMove.SetCanMove(false);
            health.SetEndScreen(true);
        }

        //Debug.Log(noCards);
    }

    public void SetHasAnyCards(bool gotACard)
    {
        noCards = gotACard;
    }
    //load the end card screen if the player picked up a card in the level
    private void OnTriggerEnter(Collider collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {

            endScrrenActivated = true;

            lulu.GetComponent<Pause>().canBePaused = false;
            overSeer.CurrentHealth = health.GetCurrentHealth();
            endLevelSound.Post(gameObject);

            //Debug.Log(playerRef.GetHasCard());
            bool LuluHasCard = playerRef.GetHasCard();

            if (LuluHasCard == true)
            {
                playVideo = false;
               endVideo.SetActive(true);
               endVideoData.Play();
            }

            if (isAlphaPortal == true && LuluHasCard == false)
            {
                if (overSeer.DodgeActive == false)
                {
                    noCards = true;
                    endVideo.SetActive(true);
                    endVideoData.Play();
                }
                else
                {
                    noCards = true;
                    endVideo.SetActive(true);
                    endVideoData.Play();

                }
            }

            if (LuluHasCard == false && isAlphaPortal == false)
            {
                noCards = true;
                endVideo.SetActive(true);
                endVideoData.Play();
            }

            lulu.transform.position = new Vector3(300, -80, 0);

        }
    }

    public void VideoLoadCrafting(VideoPlayer vp)
    {
        endVideo.SetActive(false);
        //eventSystem.firstSelectedGameObject = cardButton;
        //cardButton.GetComponent<Button>().Select();
        cardholder.SetActive(false);

        if(isAlphaPortal == false && overSeer.halfCards.Count > 0)
        {
            LoadCrafting();
        }

        if (noCards == true)
        {
            if(overSeer.DodgeActive == false && isAlphaPortal)
            {
                dodgeUnlockScreen.SetActive(true);
                overSeer.DodgeActive = true;
            }
            else
            {
                noCardPieces.SetActive(true);
            }
        }
        //else
        //{
        //    cardholder.SetActive(false);
        //    //lulu.SetActive(false);
        //    playerMove.SetCanMove(false);
        //    endScreen.SetActive(true);
        //}
        else
        {
            if (overSeer.DodgeActive == false && isAlphaPortal)
            {
                dodgeUnlockScreen.SetActive(true);
                overSeer.DodgeActive = true;

                //endScreen.SetActive(true);
            }
            if (overSeer.DodgeActive == true)
            {
                endScreen.SetActive(true);
            }

        }

    }

    public void LoadCrafting()
    {
        dodgeUnlockScreen.SetActive(false);
        if(overSeer.halfCards.Count > 0)
        {
            playerMove.SetCanMove(false);
            endScreen.SetActive(true);
            cardholder.SetActive(false);
            //lulu.SetActive(false);

        }
        else
        {
            noCardPieces.SetActive(true);
        }


    }
}
