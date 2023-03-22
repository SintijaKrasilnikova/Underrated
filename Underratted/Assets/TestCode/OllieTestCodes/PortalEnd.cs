using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnd : MonoBehaviour
{
    private int LoadNextLevel;
    public GameObject endScreen;
    public Card_Numbers playerRef;
    public PlayerMovement playerMove;
    public GameObject lulu;
    public AK.Wwise.Event endLevelSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //load the end card screen if the player picked up a card in the level
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //Debug.Log(playerRef.GetHasCard());

                if (playerRef.GetHasCard() == true)
                {
                    //lulu.SetActive(false);
                    endLevelSound.Post(gameObject);
                    playerMove.SetCanMove(false);
                    endScreen.SetActive(true);
                }
                else //if (playerRef.hasCard == false)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
