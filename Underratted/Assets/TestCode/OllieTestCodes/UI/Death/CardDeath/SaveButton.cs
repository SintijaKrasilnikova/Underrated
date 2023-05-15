using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveButton : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public Buttons[] cardButtons;
    public GameObject currentButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Buttons uiButtons in cardButtons)
        {
            if (uiButtons.selected)
            {
                currentButton = uiButtons.gameObject;
            }
        }
    }

    public void ButtonClicked()
    {
        cardOver.firstRun = false;

        //find the cards in the overseer to check if any slots are empty

        if (cardOver.loadoutCards.All(x => x != currentButton.GetComponent<DeathCardSelector>().cardID))
        {
            cardOver.loadoutCards.Add(currentButton.GetComponent<DeathCardSelector>().cardID);
        }

        cardOver.loadoutCardRecharge[currentButton.GetComponent<DeathCardSelector>().cardID] = 1.1f;
        cardOver.loadoutCardUse[currentButton.GetComponent<DeathCardSelector>().cardID] = 2;
        SceneManager.LoadScene(0);
    }
}
