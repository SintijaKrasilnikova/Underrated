using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseText : MonoBehaviour
{
    public PauseCards buff1;
    public bool isBuff1;
    public bool isBuff2;
    public bool isAbility;
    // Start is called before the first frame update
    void Start()
    {
        if (isBuff1)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = buff1.buff1Text[buff1.cardID];
        }
        if (isBuff2)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = buff1.buff2Text[buff1.cardID];
        }
        if (isAbility)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = buff1.abilityText[buff1.cardID];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
