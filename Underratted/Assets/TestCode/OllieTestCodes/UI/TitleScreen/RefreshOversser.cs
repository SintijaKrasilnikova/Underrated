using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshOversser : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            cardOver.halfCards.Clear();
            cardOver.fullCards.Clear();
            cardOver.loadoutCards.Clear();

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

            cardOver.firstRun = true;
        }
    }
}
