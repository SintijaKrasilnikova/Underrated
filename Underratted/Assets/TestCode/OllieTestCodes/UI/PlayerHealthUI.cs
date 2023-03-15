using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    // made using https://www.youtube.com/watch?v=Dn_BUIVdAPg 

    public PlayerHealth playerHealth;

    public int playersHealth = 0;

    int lastFrameHealth = 4;

    // Start is called before the first frame update
    void Start()
    {
        HealthChange();
    }

    // Update is called once per frame
    void Update()
    {
        int previousHealth = playersHealth;

        //if the players health is not the same as the last frame change the UI sprite
        if(playerHealth.currentHealth != lastFrameHealth)
        {
            if (playersHealth >= transform.childCount - 1)
                playersHealth = 0;
            else
                playersHealth++;
        }
        lastFrameHealth = playerHealth.currentHealth;

        if(previousHealth != playersHealth)
        {
            HealthChange();
        }
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
}
