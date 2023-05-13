using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleScreenStart : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public Button startButton;
    public EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        startButton.Select();
        eventSystem.firstSelectedGameObject = startButton.gameObject;

        cardOver.runStarted = true;

        cardOver.halfCards.Clear();
        cardOver.fullCards.Clear();

        cardOver.CurrentHealth = 4;

        cardOver.loadoutCardRecharge[0] = 1;
        cardOver.loadoutCardRecharge[1] = 1;
        cardOver.loadoutCardRecharge[2] = 1;
        cardOver.loadoutCardRecharge[3] = 1;
        cardOver.loadoutCardRecharge[4] = 1;
        cardOver.loadoutCardRecharge[5] = 1;

        cardOver.loadoutCardUse[0] = 2;
        cardOver.loadoutCardUse[1] = 2;
        cardOver.loadoutCardUse[2] = 2;
        cardOver.loadoutCardUse[3] = 2;
        cardOver.loadoutCardUse[4] = 2;
        cardOver.loadoutCardUse[5] = 2;

        cardOver.HealthAttack = false;
        cardOver.HealthHealth = false;
        cardOver.HealthSpeed = false;
        cardOver.SpeedSpeed = false;
        cardOver.AttackAttack = false;
        cardOver.AttackSpeed = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
