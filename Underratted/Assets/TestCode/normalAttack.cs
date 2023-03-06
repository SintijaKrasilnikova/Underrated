using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour
{

    private GameObject attackArea = default;
   // public BoxCollider attackArea;
    private bool attacking = false;
    private bool resting = false;


    private float timeToAttack = 0.5f;
    private float attackTimer = 0f;
    private float restTimer = 0f;

    public float timeBetweenAttacks = 0.6f;

    private bool soundTheSwipe = false;

    public Animator plyerAnimator;

    public AK.Wwise.Event swordSwipeSound = new AK.Wwise.Event();

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(attacking);
        timeBetweenAttacks += timeToAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && attacking == false && resting == false)
        {
            Attack();
            soundTheSwipe = true;
            resting = true;
        }
        
        if(attacking)
        {
            //if (soundTheSwipe == true)
            //{
            //    swordSwipeSound.Post(gameObject);
            //    soundTheSwipe = false;
            //}
            attackTimer += Time.deltaTime;
           
            if(attackTimer >= timeToAttack)
            {
                attackTimer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }

        }

        if(resting)
        {
            restTimer += Time.deltaTime;

            if (restTimer >= timeBetweenAttacks)
            {
                restTimer = 0;
                resting = false;
            }
        }

        plyerAnimator.SetBool("Attacking", attacking);
        
    }

    private void Attack()
    {
        attacking = true;
       
        attackArea.SetActive(attacking);
    }
}
