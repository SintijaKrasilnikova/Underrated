using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //[SerializeField] private CharacterController Controller;
    //[Space]

    [SerializeField] public float deathTime = 0.9f;
    [SerializeField] public float hurtTime = 0.3f;
    [SerializeField] public float immuneTime = 1.0f;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody playerBody;



    public Animator plyerAnimator;
    public Vector3 playerMovementInput;
    private bool immunity = false;
    private bool facingUp;
    private bool facingLeft;


    public AK.Wwise.Event footstepSound = new AK.Wwise.Event();

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
            if (Input.GetAxis("Horizontal") < 0)
            {
                plyerAnimator.SetFloat("FacingUp", 0);
                plyerAnimator.SetFloat("FacingRight", -1); //left
                footstepSound.Post(gameObject);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                plyerAnimator.SetFloat("FacingUp", 0);
                plyerAnimator.SetFloat("FacingRight", 1); //right
                footstepSound.Post(gameObject);
            }

            //up down for animation
            if (Input.GetAxis("Vertical") < 0)
            {
                plyerAnimator.SetFloat("FacingRight", 0);
                plyerAnimator.SetFloat("FacingUp", -1); //down
                footstepSound.Post(gameObject);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                plyerAnimator.SetFloat("FacingRight", 0);
                plyerAnimator.SetFloat("FacingUp", 1); //up
                footstepSound.Post(gameObject);
            }
        }

    }

    private void MovePlayer()
    {
        Vector3 movePlayer = (transform.TransformDirection(playerMovementInput) * speed);

        playerBody.velocity = new Vector3(movePlayer.x, playerBody.velocity.y, movePlayer.z);
        
    }

    public void HurtPlayer(int currentHP)
    {
        //if (immunity == false)
        //{
        //    if (currentHP <= 0)
        //    {

        //        plyerAnimator.SetBool("Death", true);
        //        Invoke(nameof(PlayerDeath), deathTime);
        //    }
        //    else
        //    {
        //        plyerAnimator.SetBool("Hurt", true);
        //        Invoke(nameof(ResetHurt), hurtTime);
        //    }
        //}
        //else
        //{
        //    Invoke(nameof(ImmunityOff), immuneTime);
        //}

        if (currentHP <= 0)
        {

            plyerAnimator.SetBool("Death", true);
            Invoke(nameof(PlayerDeath), deathTime);
        }
        else
        {
            plyerAnimator.SetBool("Hurt", true);
            Invoke(nameof(ResetHurt), hurtTime);
        }
    }

    public void ResetHurt()
    {
        plyerAnimator.SetBool("Hurt", false);
        immunity = false;
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ImmunityOff()
    {
        immunity = true;
    }


}
