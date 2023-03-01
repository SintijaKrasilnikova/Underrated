using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Vector3 velocity;
    private Vector3 playerMovementInput;

    //[SerializeField] private CharacterController Controller;
    //[Space]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody playerBody;

    private bool facingUp;
    private bool facingLeft;


    public Animator plyerAnimator;

    private float deathTime = 0.2f;
    private float deathTimer=0;
    private bool deathAnimationCalled = false;

    private float hurtTime = 0.2f;
    private float hurtTimer = 0;
    private bool hurtAnimationCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        deathAnimationCalled = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
        plyerAnimator.SetFloat("Horizontal", playerMovementInput.x);
        plyerAnimator.SetFloat("Vertical", playerMovementInput.z);
        plyerAnimator.SetFloat("Speed", playerMovementInput.sqrMagnitude);


        if (playerMovementInput.sqrMagnitude >= 0.01)
        {
            //left right for animation
            if (Input.GetAxis("Horizontal") < 0)// && Input.GetAxis("Vertical") ==0)
            {
                plyerAnimator.SetFloat("FacingUp", 0);
                plyerAnimator.SetFloat("FacingRight", -1); //left
                //playerBody.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                plyerAnimator.SetFloat("FacingUp", 0);
                plyerAnimator.SetFloat("FacingRight", 1); //right
            }

            //up down for animation
            if (Input.GetAxis("Vertical") < 0)// && Input.GetAxis("Horizontal") == 0)
            {
                plyerAnimator.SetFloat("FacingRight", 0);
                plyerAnimator.SetFloat("FacingUp", -1); //down
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                plyerAnimator.SetFloat("FacingRight", 0);
                plyerAnimator.SetFloat("FacingUp", 1); //up
            }
        }


        //player is hurting
        if (hurtAnimationCalled == true)
        {
            if (hurtTimer > hurtTime)
            {
                plyerAnimator.SetBool("Hurt", false);
                hurtAnimationCalled = false;
                hurtTimer = 0f;
            }
            else
            {
                hurtTimer += Time.deltaTime;
            }
        }
        //player has been killed
        if(deathAnimationCalled== true)
        {
            if (deathTimer > deathTime)
            {
                deathTimer = 0f;
                gameObject.SetActive(false);
            }
            else
            {
                deathTimer += Time.deltaTime;
            }
        }

    }

    private void MovePlayer()
    {
        Vector3 movePlayer = (transform.TransformDirection(playerMovementInput) * speed);

        playerBody.velocity = new Vector3(movePlayer.x, 0, movePlayer.z);
        
    }

    public void HurtPlayer(int currentHP)
    {
        if (currentHP <= 0)
        {
            
            plyerAnimator.SetBool("Death", true);
            deathAnimationCalled = true;
        }
        else
        {
            plyerAnimator.SetBool("Hurt", true);
            hurtAnimationCalled = true;
        }
    }
}
