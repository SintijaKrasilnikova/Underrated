using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    //reference https://www.youtube.com/watch?v=b1uoLBp2I1w

    private Vector3 velocity;
    private Vector3 playerMovementInput;

    [SerializeField] private CharacterController Controller;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float gravity = 9.81f;

    

    private bool facingUp;
    private bool facingLeft;


    public Animator plyerAnimator;

    // Start is called before the first frame update
    void Start()
    {

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
            else if(Input.GetAxis("Vertical") > 0)
            {
                plyerAnimator.SetFloat("FacingRight", 0);
                plyerAnimator.SetFloat("FacingUp", 1); //up
            }
        }

    }

    private void MovePlayer()
    {
        Vector3 movePlayer = transform.TransformDirection(playerMovementInput);

        if(Controller.isGrounded)
        {
            velocity.y = -1f;
        }
        else
        {
            velocity.y -= gravity * 2f * Time.deltaTime;
        }
        Controller.Move(movePlayer * speed * Time.deltaTime);
        Controller.Move(velocity);
    }
}
