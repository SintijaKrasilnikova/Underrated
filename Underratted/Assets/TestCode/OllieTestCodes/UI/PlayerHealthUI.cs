using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    // made using https://www.youtube.com/watch?v=Dn_BUIVdAPg 

    public PlayerHealth playerHealthRef;

    public int playersHealth = 0;

    int lastFrameHealth = 4;

    public GameObject[] healthSprites;
    GameObject currentSprite;

    // Start is called before the first frame update
    void Start()
    {
        HealthChange();
    }

    // Update is called once per frame
    void Update()
    {
        playersHealth = playerHealthRef.currentHealth;
        if(playersHealth > 0)
        {
            HideHealth();
            currentSprite = healthSprites[playersHealth];
            currentSprite.SetActive(true);
        }

        if(playersHealth < 0)
        {
            currentSprite = healthSprites[0];
            currentSprite.SetActive(true);
        }

        //int previousHealth = playersHealth;

        //if the players health is not the same as the last frame change the UI sprite
        //if(playerHealth.currentHealth < lastFrameHealth)
        //{
        //    if (playersHealth >= transform.childCount - 1)
        //        playersHealth = 0;
        //    else
        //        playersHealth++;
        //}
        //if (playerHealth.currentHealth > lastFrameHealth)
        //{
        //    if (playersHealth >= transform.childCount - 1)
        //        playersHealth = 0;
        //    else
        //        playersHealth--;
        //}
        //lastFrameHealth = playerHealth.currentHealth;

        //if(previousHealth != playersHealth)
        //{
        //    HealthChange();
        //}
    }

    void HealthChange()
    {
        //get all the children of the Holder and only set the current one to true
        int i = 0;
        foreach (Transform health in transform)
        {
            if (i == playersHealth)
                health.gameObject.SetActive(true);
            else
                health.gameObject.SetActive(false);
            i++;
        }
    }

    void HideHealth()
    {
        foreach(var card in healthSprites)
        {
            card.SetActive(false);
        }
    }
}
