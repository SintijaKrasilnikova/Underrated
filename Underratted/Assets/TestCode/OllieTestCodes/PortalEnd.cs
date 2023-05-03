using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    // Start is called before the first frame update
    void Start()
    {
        health = playerRef.GetComponent<PlayerHealth>();
        //overSeer = playerRef.GetComponent<CardOverseer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //load the end card screen if the player picked up a card in the level
    private void OnTriggerEnter(Collider collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {

            overSeer.CurrentHealth = health.GetCurrentHealth();

            //Debug.Log(playerRef.GetHasCard());
            bool LuluHasCard = playerRef.GetHasCard();

            if (LuluHasCard == true)
            {
                if(playVideo == false)
                {
                    cardholder.SetActive(false);
                    //lulu.SetActive(false);
                    endLevelSound.Post(gameObject);
                    playerMove.SetCanMove(false);
                    endScreen.SetActive(true);
                }
                else
                {
                    endVideo.SetActive(true);
                    endVideoData.Play();
                }
            }

            if (isAlphaPortal == true && LuluHasCard == false)
            {
                if (overSeer.DodgeActive == false)
                {
                    dodgeUnlockScreen.SetActive(true);
                }
            }

            if (LuluHasCard == false && isAlphaPortal == false)
            {
                noCardPieces.SetActive(true);
            }


        }
    }

    public void VideoLoadCrafting(VideoPlayer vp)
    {
        if (playVideo)
        {
            endVideo.SetActive(false);
        }

        cardholder.SetActive(false);
        //lulu.SetActive(false);
        endLevelSound.Post(gameObject);
        playerMove.SetCanMove(false);
        endScreen.SetActive(true);
    }

    public void LoadCrafting()
    {
        cardholder.SetActive(false);
        //lulu.SetActive(false);
        endLevelSound.Post(gameObject);
        playerMove.SetCanMove(false);
        endScreen.SetActive(true);
    }
}
