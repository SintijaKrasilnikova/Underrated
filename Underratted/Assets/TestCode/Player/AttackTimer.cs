using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{
    public PlayerMovement movementRef;

    public GameObject basicAttackArea = default;
    public GameObject spinAttackArea = default;
    public GameObject trailAttackArea = default;
    private bool spinAttackActive = true;
    private GameObject currentAttackArea = default;



    private bool attacking = false;
    private bool resting = false;

    public int baseDamage = 3;
    private int startBaseDamage = 3;

    public bool lulu4 = false;
    public float basicAttackTime = 0.6f;
    public float spinAttackTime = 1.0f;

    //cooldown tracker values
    private float currentRestTime = 0f;
    public float spinFillValue = 0;
    public float normAttackFillValue = 0;

    //max values for the ability cooldown
    public float normalRestTime = 1.0f;
    public float spinRestTime = 3.0f;

    public Animator plyerAnimator;
    public AK.Wwise.Event swordSwipeSound;
    public AK.Wwise.Event spinSwipeSound;


    public bool critPossibleActive = false;
    public int critChance = 10;
    public int critDamageValue = 10;
    public bool willCrit = false;

    public bool damageTrailActivated = false;

   





    // Start is called before the first frame update
    void Start()
    {
        if (lulu4 == false)
        {
            basicAttackArea = transform.GetChild(0).gameObject;
            basicAttackArea.SetActive(false);
            spinAttackArea = transform.GetChild(1).gameObject;
            spinAttackArea.SetActive(false);

            trailAttackArea = transform.GetChild(3).gameObject;
        }
        //trailAttackArea.SetActive(false);

        startBaseDamage = baseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking == false && resting == false)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                SetCurrentAttackActive(true, "normal");
                Invoke(nameof(EndAttack), basicAttackTime);
            }

            else if (Input.GetKeyDown(KeyCode.O) && spinAttackActive == true)
            {
                SetCurrentAttackActive(true, "spin");
                Invoke(nameof(EndAttack), spinAttackTime);
            }

        }

        if(damageTrailActivated)
        {
            trailAttackArea.SetActive(true);
        }

        //if(resting == true)
        //{
        //    UiValueRegen(spinFillValue, spinRestTime);
        //    UiValueRegen(normAttackFillValue, normalRestTime);

        //}

        //UiValueRegen(spinFillValue, spinRestTime);
        spinFillValue = UiValueRegen(spinFillValue, spinRestTime);
        normAttackFillValue = UiValueRegen(normAttackFillValue, normalRestTime);

        Debug.Log(spinFillValue);
        Debug.Log(normAttackFillValue);

    }

    public void SetTrailAreaActive()
    {
        trailAttackArea.SetActive(true);
        damageTrailActivated = true;
    }

    public void SetSpinActive(bool active)
    {
        spinAttackActive = active;
    }

    public void SetCurrentAttackActive(bool active, string attackType)
    {

        movementRef.SetCanDoge(false);
        
        if (critPossibleActive )
        {
            int randomCritChance = UnityEngine.Random.Range(1, 100);

            if(randomCritChance< critChance)
            {

                willCrit = true;
                baseDamage = critDamageValue;
            }
            else
            {
                willCrit = false;
            }
        }

        //sets active/inactive the currentAttackArea based on type and plays the according sound/animation
        if (active)
        {
            
            switch (attackType)
            {
                case "normal":
                    {
                        swordSwipeSound.Post(gameObject);

                        currentAttackArea = basicAttackArea;
                        plyerAnimator.SetBool("Attacking", active);
                        break;
                    }
                case "spin":
                    {

                        spinSwipeSound.Post(gameObject);

                        currentAttackArea = spinAttackArea;
                        plyerAnimator.SetBool("Spin", active);
                        break;
                    }

                default:
                    // code block
                    break;
            }

        }
        else
        {
            plyerAnimator.SetBool("Attacking", false);
            plyerAnimator.SetBool("Spin", false);
        }

        attacking = active;
        currentAttackArea.SetActive(active);
    }

    public void EndAttack()
    {

        if(plyerAnimator.GetBool("Spin") == true)
        {
            currentRestTime = spinRestTime;
            spinFillValue = 0;

        }
        else
        {
            currentRestTime = normalRestTime;
            normAttackFillValue = 0;
        }

        //set animations back to movement
        plyerAnimator.SetBool("Attacking", false);
        plyerAnimator.SetBool("Spin", false);
        movementRef.SetCanDoge(true);

        //disable the attack area
        attacking = false;
        currentAttackArea.SetActive(false);

        baseDamage = startBaseDamage;
        //call the rest time
        resting = true;
        Invoke(nameof(ResetRest), currentRestTime);

    }

    public float UiValueRegen(float value, float valueMax)
    {
        if(value<valueMax)
        {
            value += Time.deltaTime;
        }
        else
        {
            value = valueMax;
        }

        return value;
    }

    public void ResetRest()
    {
        resting = false;

    }

    public int GetBaseDamage()
    {
        return baseDamage;
    }

    public void IncreaseBaseDamage(int inc)
    {
        baseDamage += inc;
    }

    public void SetCritPossibleActive()
    {
        critPossibleActive = true;
    }

    public void ChangeRestTime()
    {
        //currentRestTime /= 2;

        normalRestTime /= 2;
        spinRestTime /= 2;
}
}
