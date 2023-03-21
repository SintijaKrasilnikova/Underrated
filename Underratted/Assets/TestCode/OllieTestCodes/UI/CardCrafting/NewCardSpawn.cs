using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCardSpawn : MonoBehaviour
{
    public CardAbilityNames cardAbilityRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        var cardImage = gameObject.GetComponent<Image>();
        cardImage.sprite = cardAbilityRef.abilities[cardAbilityRef.abilityNumb];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
