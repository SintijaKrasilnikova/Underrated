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
        cardOver.loadoutCardUse[passive1.selectedCard.cardID] = passive1.selectedCard.cardUse;
        cardOver.loadoutCardUse[passive2.selectedCard.cardID] = passive2.selectedCard.cardUse;

        if(passive1.selectedCard.cardUse <= 0)
        {
            cardOver.loadoutCardRecharge[passive1.selectedCard.cardID] = 0f;
        }
        if (passive2.selectedCard.cardUse <= 0)
        {
            cardOver.loadoutCardRecharge[passive2.selectedCard.cardID] = 0f;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
