using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //find the cards in the overseer to check if any slots are empty
        foreach (int slot in cardOver.loadoutCards)
        {
            //if so, break and add card to that slot
            if (cardOver.loadoutCards[slot] == 0)
            {
                cardOver.loadoutCards[slot] = currentButton.GetComponent<DeathCardSelector>().cardID;
                break;
            }
        }
        SceneManager.LoadScene(0);
    }
}
