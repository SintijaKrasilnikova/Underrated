using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardStart_StartGame : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public CardStart_Buttons passive1;
    public CardStart_Buttons passive2;
    public CardStart_Buttons skill1;
    public CardStart_Buttons skill2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        cardOver.fullCards.Clear();
        ClearCards();

        if(passive1.selectedCard != null)
        {
            cardOver.fullCards.Add(cardOver.loadoutCards[passive1.selectedCard.cardID]);
            cardOver.loadoutCardUse[passive1.selectedCard.cardID] = passive1.selectedCard.cardUse;
            testActivate1();
        }
        if(passive2.selectedCard != null)
        {
            cardOver.fullCards.Add(cardOver.loadoutCards[passive2.selectedCard.cardID]);
            cardOver.loadoutCardUse[passive2.selectedCard.cardID] = passive2.selectedCard.cardUse;
            testActivate2();
        }


        if (passive1.selectedCard != null && passive1.selectedCard.cardUse <= 0)
        {
            cardOver.loadoutCardRecharge[passive1.selectedCard.cardID] = 0f;
        }
        if (passive2.selectedCard != null && passive2.selectedCard.cardUse <= 0)
        {
            cardOver.loadoutCardRecharge[passive2.selectedCard.cardID] = 0f;
        }

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
