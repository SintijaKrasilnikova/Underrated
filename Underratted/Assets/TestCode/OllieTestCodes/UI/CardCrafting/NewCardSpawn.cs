using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewCardSpawn : MonoBehaviour
{
    public CardAbilityNames cardAbilityRef;

    [SerializeField] private CardOverseer cardOver;

    public bool canRemoveListEle = true;

    // Start is called before the first frame update
    void Start()
    {


    }

    private void Awake()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        if (canRemoveListEle)
        {
            cardOver.halfCards.RemoveAt(0);
            canRemoveListEle = false;
        }
    }

    public void makeNewCard()
    {
        //Debug.Log("Combined");
        var cardImage = gameObject.GetComponent<Image>();
        cardImage.sprite = cardAbilityRef.abilities[cardAbilityRef.abilityNumb];

        switch (cardAbilityRef.GetAbilityNumber())
        {
            case 1://Speed + Speed ability
                cardOver.SpeedSpeed = true;
                cardOver.fullCards.Add(1);
                break;
            case 2://Speed + Attack ability
                cardOver.AttackSpeed = true;
                cardOver.fullCards.Add(2);
                break;
            case 3://Speed + Health ability
                cardOver.HealthSpeed = true;
                cardOver.fullCards.Add(3);
                break;
            case 4://Attack + Attack ability
                cardOver.AttackAttack = true;
                cardOver.fullCards.Add(4);
                break;
            case 5://Health + Attack ability
                cardOver.HealthAttack = true;
                cardOver.fullCards.Add(5);
                break;
            case 6://Health + Health ability
                cardOver.HealthHealth = true;
                cardOver.fullCards.Add(6);
                break;
        }

        //SceneManager.LoadScene(0);
    }
}
