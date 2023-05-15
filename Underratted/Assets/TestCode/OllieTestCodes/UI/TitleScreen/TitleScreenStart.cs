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
