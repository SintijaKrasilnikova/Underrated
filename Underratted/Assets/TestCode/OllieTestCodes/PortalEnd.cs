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
    public GameObject cardholder;

    public bool isAlphaPortal = false;
    public PlayerHealth health;
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
                    cardholder.SetActive(false);
                    //lulu.SetActive(false);
                    endLevelSound.Post(gameObject);
                    playerMove.SetCanMove(false);
                    endScreen.SetActive(true);
                }
                if (isAlphaPortal)
                {
                    health.TakeDamage(100);
                }
                if (playerRef.hasCard == false)
                {
                    //SceneManager.LoadScene(1);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }


            }
        }
    }
}
