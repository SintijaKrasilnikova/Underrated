using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //[SerializeField] private CharacterController Controller;
    //[Space]

    [SerializeField] public float deathTime = 0.9f;
    [SerializeField] public float hurtTime = 0.3f;
    [SerializeField] public float immuneTime = 1.0f;
    [SerializeField] public float dodgeTime = 0.8f;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody playerBody;
   


    public Animator plyerAnimator;
    public Vector3 playerMovementInput;
    private bool immunity = false;
    private bool facingUp;
    private bool facingLeft;
    private bool spedUp = false;
    private bool canMove = true;
    private bool canDodge = true;

    public CinemachineVirtualCamera deathCam;
    public GameObject deathUI;


    public AK.Wwise.Event footstepSound = new AK.Wwise.Event();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Dodge();

        MovePlayer();
        plyerAnimator.SetFloat("Horizontal", playerMovementInput.x);
        plyerAnimator.SetFloat("Vertical", playerMovementInput.z);
        plyerAnimator.SetFloat("Speed", playerMovementInput.sqrMagnitude);




        if (playerMovementInput.sqrMagnitude >= 0.01 && canMove ==true)
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

    private void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.O) && canDodge == true)
        {
            canMove = false;
            plyerAnimator.SetBool("Dodging", true);
            canDodge = false;
            float dodgeForceValue = 5000f;
            Vector3 dodgeForce = new Vector3(0, 0, 0);
            if (plyerAnimator.GetFloat("FacingUp") == 1)
            {
                // dodgeForce = new Vector3(dodgeForce.x, dodgeForce.y, dodgeForce.z - dodgeForceValue);
                dodgeForce = new Vector3(0, dodgeForce.y, -dodgeForceValue);
            }
            else if (plyerAnimator.GetFloat("FacingUp") == -1)
            {
                //dodgeForce = new Vector3(dodgeForce.x, dodgeForce.y, dodgeForce.z + dodgeForceValue);
                dodgeForce = new Vector3(0, dodgeForce.y, +dodgeForceValue);
            }

            if (plyerAnimator.GetFloat("FacingRight") == -1)
            {
                //dodgeForce = new Vector3(dodgeForce.x + dodgeForceValue, dodgeForce.y, dodgeForce.z);
                dodgeForce = new Vector3(+dodgeForceValue, dodgeForce.y, 0);
            }
            else if (plyerAnimator.GetFloat("FacingRight") == 1)
            {
                //dodgeForce = new Vector3(dodgeForce.x - dodgeForceValue, dodgeForce.y, dodgeForce.z);
                dodgeForce = new Vector3(-dodgeForceValue, dodgeForce.y, 0);
            }
            playerBody.AddForce(dodgeForce);
            Invoke(nameof(RestoreDodge), dodgeTime);
            //Debug.Log("Dodge called");
        }
    }

    public void RestoreDodge()
    {
        canMove = true;
        plyerAnimator.SetBool("Dodging", false);
        canDodge = true;
    }
    public void SetCanMove(bool canMoveNow)
    {
        canMove = canMoveNow;
    }

    private void MovePlayer()
    {
        if (canMove == true)
        {
            Vector3 movePlayer = (transform.TransformDirection(playerMovementInput) * speed);

            playerBody.velocity = new Vector3(movePlayer.x, playerBody.velocity.y, movePlayer.z);
        }
        
    }

    public void HurtPlayer(int currentHP)
    {

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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        canMove = false;
        deathCam.Priority = 21;
        deathUI.SetActive(true);
        this.GetComponent<Renderer>().sortingOrder = 1;
    }

    public void ImmunityOff()
    {
        immunity = true;
    }


    public void SpeedUp()
    {
        if (spedUp == false)
        {
            speed *= 1.5f;
            spedUp = true;
        }
    }

}
