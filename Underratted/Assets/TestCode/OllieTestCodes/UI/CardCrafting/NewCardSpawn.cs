using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewCardSpawn : MonoBehaviour
{
    public CardAbilityNames cardAbilityRef;

    [SerializeField] private CardOverseer cardOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //Debug.Log("Combined");
        var cardImage = gameObject.GetComponent<Image>();
        cardImage.sprite = cardAbilityRef.abilities[cardAbilityRef.abilityNumb];

        switch(cardAbilityRef.GetAbilityNumber())
        {
            case 1://Speed + Speed ability
                cardOver.SpeedSpeed = true;
                break;
            case 2://Speed + Attack ability
                cardOver.AttackSpeed = true;
                break;
            case 3://Speed + Health ability
                cardOver.HealthSpeed = true;
                break;
            case 4://Attack + Attack ability
                cardOver.AttackAttack = true;
                break;
            case 5://Health + Attack ability
                cardOver.HealthAttack = true;
                break;
            case 6://Health + Health ability
                cardOver.HealthHealth = true;
                break;
        }

        //SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
