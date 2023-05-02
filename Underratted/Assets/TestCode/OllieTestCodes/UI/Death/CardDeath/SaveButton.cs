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
        //find the cards in the overseer to check if any slots are empty

        if(cardOver.loadoutCards.All(x => x != currentButton.GetComponent<DeathCardSelector>().cardID))
        {
            cardOver.loadoutCards.Add(currentButton.GetComponent<DeathCardSelector>().cardID);
            cardOver.loadoutCardUse.Add(2);
            cardOver.loadoutCardRecharge.Add(1.1f);
        }
        SceneManager.LoadScene(0);
    }
}
