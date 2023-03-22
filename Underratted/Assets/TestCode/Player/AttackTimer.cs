using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{
    private GameObject basicAttackArea = default;
    private GameObject spinAttackArea = default;
    private bool spinAttackActive = false;
    private GameObject currentAttackArea = default;


    private bool attacking = false;
    private bool resting = false;

    public int baseDamage = 3;

    public float basicAttackTime = 0.6f;
    public float spinAttackTime = 1.0f;
    public float restTime = 1.0f;

    public Animator plyerAnimator;
    public AK.Wwise.Event swordSwipeSound;
    public AK.Wwise.Event spinSwipeSound;

<<<<<<< Updated upstream
=======
    public bool critPossibleActive = false;
    public int critChance = 10;
    public int critDamageValue = 10;
    public bool willCrit = false;


>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        basicAttackArea = transform.GetChild(0).gameObject;
        basicAttackArea.SetActive(false);
        spinAttackArea = transform.GetChild(1).gameObject;
        spinAttackArea.SetActive(false);
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
                Invoke(nameof(EndAttack), basicAttackTime);
            }

        }
    }

    public void SetSpinActive(bool active)
    {
        spinAttackActive = active;
    }

    public void SetCurrentAttackActive(bool active, string attackType)
    {
<<<<<<< Updated upstream
=======

        
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
>>>>>>> Stashed changes
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
        //set animations back to movement
        plyerAnimator.SetBool("Attacking", false);
        plyerAnimator.SetBool("Spin", false);

        //disable the attack area
        attacking = false;
        currentAttackArea.SetActive(false);

        //call the rest time
        resting = true;
        Invoke(nameof(ResetRest), restTime);

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

}
