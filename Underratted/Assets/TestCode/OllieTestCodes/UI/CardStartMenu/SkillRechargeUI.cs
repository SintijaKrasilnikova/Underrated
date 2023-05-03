using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillRechargeUI : MonoBehaviour
{

    [SerializeField] private Image skillBar;
    [SerializeField] private AttackTimer spinValueRef;
    [SerializeField] private PlayerMovement dodgeValueRef;
    [SerializeField] private bool spinIcon = false;
    [SerializeField] private bool dodgeIcon = false;


    // Start is called before the first frame update
    void Start()
    {
        skillBar = this.GetComponent<Image>();
        spinValueRef = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackTimer>();
        dodgeValueRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (spinIcon)
            skillBar.fillAmount = spinValueRef.GetSpinFillValue() / spinValueRef.spinRestTime;

        if (dodgeIcon)
            skillBar.fillAmount = dodgeValueRef.GetDodgeTimerValue() / dodgeValueRef.dodgeCooldown;


        //Debug.Log(valueRef.spinAttackTime);
    }
}
