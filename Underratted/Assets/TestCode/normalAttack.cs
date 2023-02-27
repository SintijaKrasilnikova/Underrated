using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalAttack : MonoBehaviour
{

    private GameObject attackArea = default;
   // public BoxCollider attackArea;
    private bool attacking = false;
    private float timeToAttack = 0.6f;
    private float timer = 0f;

    private bool soundTheSwipe = false;

    public Animator plyerAnimator;

    public AK.Wwise.Event swordSwipeSound = new AK.Wwise.Event();

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(attacking);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && attacking ==false)
        {
            Attack();
            soundTheSwipe = true;
        }
        
        if(attacking)
        {
            if (soundTheSwipe == true)
            {
                swordSwipeSound.Post(gameObject);
                soundTheSwipe = false;
            }
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
               
                attacking = false;
                attackArea.SetActive(attacking);
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
