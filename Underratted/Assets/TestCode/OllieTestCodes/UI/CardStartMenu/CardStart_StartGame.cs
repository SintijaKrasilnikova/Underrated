using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardStart_StartGame : MonoBehaviour
{
    //[SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private CardOverseer cardOver;
    public CardStart_Buttons passive1;
    public CardStart_Buttons passive2;
    public CardStart_Buttons skill1;
    public CardStart_Buttons skill2;

    public AK.Wwise.Event musicStop;
    public GameObject mainCamera;

    public int cardAmount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        cardOver.fullCards.Clear();
        cardOver.CurrentHealth = 4;
        ClearCards();

        if(passive1.selectedCard != null)
        {
            
            cardAmount++;

            cardOver.fullCards.Add(passive1.equippedID -1);
            cardOver.loadoutCardUse[passive1.equippedID] = passive1.selectedCard.cardUse;
            
            testActivate1();
        }
        if(passive2.selectedCard != null)
        {
            cardAmount++;
            cardOver.fullCards.Add(passive2.equippedID -1);
            cardOver.loadoutCardUse[passive2.equippedID] = passive2.selectedCard.cardUse;
            testActivate2();
        }


        if (passive1.selectedCard != null && passive1.selectedCard.cardUse <= 0)
        {
            if(cardOver.loadoutCardRecharge[passive1.equippedID] > 1)
            {
                cardOver.loadoutCardRecharge[passive1.equippedID] = 0f;
            }
        }
        if (passive2.selectedCard != null && passive2.selectedCard.cardUse <= 0)
        {
            if (cardOver.loadoutCardRecharge[passive2.equippedID] > 1)
            {
                cardOver.loadoutCardRecharge[passive2.equippedID] = 0f;
            }
        }

        cardOver.cardsEquippedInLoadout = cardAmount;

        //playerHealth.SetCurrentHealthToMax();
        //mainCamera = GameObject.Find("MainCamera");
        musicStop.Post(mainCamera);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ClearCards()
    {
        cardOver.SpeedSpeed = false;
        cardOver.AttackSpeed = false;
        cardOver.HealthSpeed = false;
        cardOver.AttackAttack = false;
        cardOver.HealthAttack = false;
        cardOver.HealthHealth = false;
    }
    void testActivate1()
    {
        if(passive1.selectedCard.cardID == 1)
        {
            cardOver.SpeedSpeed = true;
        }
        if (passive1.selectedCard.cardID == 2)
        {
            cardOver.AttackSpeed = true;
        }
        if (passive1.selectedCard.cardID == 3)
        {
            cardOver.HealthSpeed = true;
        }
        if (passive1.selectedCard.cardID == 4)
        {
            cardOver.AttackAttack = true;
        }
        if (passive1.selectedCard.cardID == 5)
        {
            cardOver.HealthAttack = true;
        }
        if (passive1.selectedCard.cardID == 6)
        {
            cardOver.HealthHealth = true;
        }
    }
    void testActivate2()
    {
        if (passive2.selectedCard.cardID == 1)
        {
            cardOver.SpeedSpeed = true;
        }
        if (passive2.selectedCard.cardID == 2)
        {
            cardOver.AttackSpeed = true;
        }
        if (passive2.selectedCard.cardID == 3)
        {
            cardOver.HealthSpeed = true;
        }
        if (passive2.selectedCard.cardID == 4)
        {
            cardOver.AttackAttack = true;
        }
        if (passive2.selectedCard.cardID == 5)
        {
            cardOver.HealthAttack = true;
        }
        if (passive2.selectedCard.cardID == 6)
        {
            cardOver.HealthHealth = true;
        }
    }

    //void passive1Activate()
    //{
    //    switch (passive1.selectedCard.cardID)
    //    {
    //        case 1:
    //            cardOver.SpeedSpeed = true;
    //            break;

    //        case 2:
    //            cardOver.AttackSpeed = true;
    //            break;

    //        case 3:
    //            cardOver.HealthSpeed = true;
    //            break;

    //        case 4:
    //            cardOver.AttackAttack = true;
    //            break;

    //        case 5:
    //            cardOver.HealthAttack = true;
    //            break;

    //        case 6:
    //            cardOver.HealthHealth = true;
    //            break;
    //    }
    //}
}
