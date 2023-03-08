using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{

    public Animator plyerAnimator;
    private GameObject basicAttackArea = default;
    private GameObject spinAttackArea = default;
    private bool spinAttackActive = false;

    private GameObject currentAttackArea = default;


    private bool attacking = false;
    private bool resting = false;

    private float attackTimer = 0f;
    private float restTimer = 0f;

    private float currentAttackTime=0f;

    public float basicAttackTime=0.6f;
    public float spinAttackTime = 1.0f;
    public float restTime = 0.5f;

    public bool soundTheSwipe = false; 
    public bool soundTheSpin = false; 
    public AK.Wwise.Event swordSwipeSound;
    public AK.Wwise.Event spinSwipeSound;


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
                attacking = true;
                currentAttackTime = basicAttackTime;
                basicAttackArea.SetActive(true);
                currentAttackArea = basicAttackArea;
                soundTheSwipe = true;

                plyerAnimator.SetBool("Attacking", true);
            }

            else if (Input.GetKeyDown(KeyCode.O) && spinAttackActive == true)
            {
                attacking = true;
                currentAttackTime = spinAttackTime;
                spinAttackArea.SetActive(true);
                currentAttackArea = spinAttackArea;
                soundTheSpin = true;

                plyerAnimator.SetBool("Spin", true);
            }

        }

        TimedAttack(currentAttackTime, restTime);

    }

    public void TimedAttack(float attackTime, float restTime)
    {
        if (attacking)
        {
            if (soundTheSwipe == true)
            {
                swordSwipeSound.Post(gameObject);
                soundTheSwipe = false;
            }

            if (soundTheSpin == true)
            {
                spinSwipeSound.Post(gameObject);
                soundTheSpin = false;
            }

            attackTimer += Time.deltaTime;
            
            if (attackTimer >= attackTime)
            {
                attackTimer = 0;
                attacking = false;
                plyerAnimator.SetBool("Attacking", false);
                plyerAnimator.SetBool("Spin", false);

                if (currentAttackArea)
                {
                    currentAttackArea.SetActive(false);
                    resting = true;
                }
            }

        }

        if (resting == true && attacking==false)
        {
            restTimer += Time.deltaTime;

            if (restTimer >= restTime)
            {
                restTimer = 0;
                resting = false;
            }
        }
    }

    public void setSpinActive(bool active)
    {
        spinAttackActive = active;
    }
}
