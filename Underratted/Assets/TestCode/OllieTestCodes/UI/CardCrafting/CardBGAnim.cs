using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBGAnim : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public GameObject assets;
    public EventSystem eventSystem;
    public GameObject deathCard;
    public bool isBG;
    public GameObject pickcardTest;
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
        assets.SetActive(true);
        if (isBG)
        {
            cardOver.rechargeCards();
            eventSystem.SetSelectedGameObject(deathCard);
        }
    }

    public void test()
    {
        pickcardTest.SetActive(true);
    }
}
