using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBGAnim : MonoBehaviour
{
    public GameObject assets;
    public EventSystem eventSystem;
    public GameObject deathCard;
    public bool isBG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeateAssets()
    {
        if (isBG)
        {
            eventSystem.SetSelectedGameObject(deathCard);
        }
        assets.SetActive(true);
    }
}
