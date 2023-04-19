using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RechargeBar : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public CardStart_Cards cardStart;
    public float fillValue;
    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fillValue = cardOver.loadoutCardRecharge[cardStart.cardID];
        bar.fillAmount = fillValue;
    }
}
