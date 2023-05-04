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
    [SerializeField] public float dodgeCooldown = 3f;
    [Space]
    [SerializeField] public float speed;
    [SerializeField] private Rigidbody playerBody;
    private PlayerHealth health;

    [SerializeField] public GameObject dodgeUI;

    public Animator plyerAnimator;
    public Vector3 playerMovementInput;
    private bool immunity = false;
    private bool facingUp;
    private bool facingLeft;
    private bool spedUp = false;
    private bool canMove = true;
    private bool canDodge = true;
    private bool dodgeAvailable = false;
    private bool dodgeTimerReady = true;
    private bool movingDiognaly = false;
    private bool playerCanControl = true;

    private bool dodgeIconIsUp = false;

    private float speedRef;
    private float dodgeCooldownTimer = 0;
    //1-left
    //2-right
    //3-down
    //4-up
    private int lastDirection = 1;

    public CinemachineVirtualCamera deathCam;
    public GameObject deathUI;


    public AK.Wwise.Event footstepSound = new AK.Wwise.Event();
    public AK.Wwise.Event playerDodge;
    public AK.Wwise.Event deathSound;
    public AK.Wwise.Event playerHitSound;
    [SerializeField] private AK.Wwise.Switch deathSwitch;
    public GameObject mainCamera;

    //just for alpha for the swipe down animation
    public GameObject slashDown;

    // Start is called before the first frame update
    void Start()
    {
        speedRef = speed;
        dodgeCooldownTimer = dodgeCooldown;
        health = this.gameObject.GetComponent<PlayerHealth>();

        if (dodgeAvailable )//&& dodgeIconIsUp == false)
        {
            dodgeUI.SetActive(true);
            //dodgeIconIsUp = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //if (dodgeAvailable && dodgeIconIsUp == false)
        //{
        //    dodgeUI.SetActive(true);
        //    dodgeIconIsUp = true;
        //}

        if (health.IsLuluDead() == false)
        {
            if (dodgeCooldownTimer < dodgeCooldown && dodgeTimerReady == false)
            {
                dodgeCooldownTimer += Time.deltaTime;

                if (dodgeCooldownTimer > dodgeCooldown)
                    dodgeCooldownTimer = dodgeCooldown;
            }
            if (dodgeCooldownTimer >= dodgeCooldown)
            {
                dodgeTimerReady = true;
                //dodgeCooldownTimer = 0;
            }

            if (playerCanControl == true)
            {
                playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            }
            else
                playerMovementInput = new Vector3(0, 0, 0);

            //playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (playerCanControl == true)
            {
                //MovePlayer();
                plyerAnimator.SetFloat("Horizontal", playerMovementInput.x);
                plyerAnimator.SetFloat("Vertical", playerMovementInput.z);
                plyerAnimator.SetFloat("Speed", playerMovementInput.sqrMagnitude);

                if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
                {
                    movingDiognaly = true;
                }
                else
                {
                    movingDiognaly = false;
                }

                if (playerMovementInput.sqrMagnitude >= 0.01 && canMove == true)
                {
                    //MovePlayer();
                    //left right for animation
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        // plyerAnimator.SetFloat("FacingUp", 0);
                        plyerAnimator.SetFloat("FacingRight", -1); //left
                        lastDirection = 1;
                        footstepSound.Post(gameObject);

                        if (Input.GetAxis("Vertical") == 0)
                        {
                            plyerAnimator.SetFloat("FacingUp", 0);
                        }
                    }
                    else if (Input.GetAxis("Horizontal") > 0)
                    {
                        //plyerAnimator.SetFloat("FacingUp", 0);
                        plyerAnimator.SetFloat("FacingRight", 1); //right
                        lastDirection = 2;
                        footstepSound.Post(gameObject);

                        if (Input.GetAxis("Vertical") == 0)
                        {
                            plyerAnimator.SetFloat("FacingUp", 0);
                        }
                    }

                    //up down for animation
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        //plyerAnimator.SetFloat("FacingRight", 0);
                        plyerAnimator.SetFloat("FacingUp", -1); //down
                        lastDirection = 3;
                        footstepSound.Post(gameObject);

                        if (Input.GetAxis("Horizontal") == 0)
                        {
                            plyerAnimator.SetFloat("FacingRight", 0);
                        }
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        //plyerAnimator.SetFloat("FacingRight", 0);
                        plyerAnimator.SetFloat("FacingUp", 1); //up
                        lastDirection = 4;
                        footstepSound.Post(gameObject);

                        if (Input.GetAxis("Horizontal") == 0)
                        {
                            plyerAnimator.SetFloat("FacingRight", 0);
                        }
                    }
                }
                else
                {
                    //1-left
                    //2-right
                    //3-down
                    //4-up
                    switch (lastDirection)
                    {
                        case 1:
                            {
                                plyerAnimator.SetFloat("FacingUp", 0);
                                plyerAnimator.SetFloat("FacingRight", -1); //left
                                break;
                            }
                        case 2:
                            {
                                plyerAnimator.SetFloat("FacingUp", 0);
                                plyerAnimator.SetFloat("FacingRight", 1); //right
                                break;
                            }
                        case 3:
                            {
                                plyerAnimator.SetFloat("FacingRight", 0);
                                plyerAnimator.SetFloat("FacingUp", -1); //down
                                break;
                            }
                        case 4:
                            {
                                plyerAnimator.SetFloat("FacingRight", 0);
                                plyerAnimator.SetFloat("FacingUp", 1); //up
                                break;
                            }
                    }
                }
            }

            Dodge();
        }
    }

    void FixedUpdate()
    {
        if(canMove && health.IsLuluDead() == false)
            MovePlayer();
    }

    public float GetDodgeTimerValue()
    {
        return dodgeCooldownTimer;
    }

    public void SetDodgeIsAvailable()
    {
        dodgeAvailable = true;
        if (dodgeAvailable)
        {
            dodgeUI.SetActive(true);
        }
    }

    public void SetCanDoge(bool newCanDodge)
    {
        if(dodgeAvailable)
            canDodge = newCanDodge;
    }

    private void Dodge()
    {
        if (dodgeAvailable && dodgeTimerReady)
        {
            if (Input.GetKeyDown(KeyCode.P) && canDodge == true)
            {
                //canMove = false;
                dodgeCooldownTimer = 0;
                dodgeTimerReady = false;
                playerCanControl = false;
                plyerAnimator.SetBool("Dodging", true);
                canDodge = false;
                float dodgeForceValue = 25000f;
                Vector3 dodgeForce = new Vector3(0, 0, 0);
                playerDodge.Post(gameObject);
                if (plyerAnimator.GetFloat("FacingUp") == 1)
                {
                    dodgeForce = new Vector3(dodgeForce.x, dodgeForce.y, dodgeForce.z - dodgeForceValue);
                    //dodgeForce = new Vector3(0, dodgeForce.y, -dodgeForceValue);
                }
                else if (plyerAnimator.GetFloat("FacingUp") == -1)
                {
                    dodgeForce = new Vector3(dodgeForce.x, dodgeForce.y, dodgeForce.z + dodgeForceValue);
                    //dodgeForce = new Vector3(0, dodgeForce.y, +dodgeForceValue);
                }

                //if(movingDiognaly ==false)
                //{
                //    dodgeForce.z = 0;
                //}

                if (plyerAnimator.GetFloat("FacingRight") == -1)
                {
                    if (movingDiognaly == false)
                    {
                        dodgeForce.z = 0;
                    }
                    dodgeForce = new Vector3(dodgeForce.x + dodgeForceValue, dodgeForce.y, dodgeForce.z);
                    //dodgeForce = new Vector3(+dodgeForceValue, dodgeForce.y, 0);
                }
                else if (plyerAnimator.GetFloat("FacingRight") == 1)
                {
                    if (movingDiognaly == false)
                    {
                        dodgeForce.z = 0;
                    }
                    dodgeForce = new Vector3(dodgeForce.x - dodgeForceValue, dodgeForce.y, dodgeForce.z);
                    //dodgeForce = new Vector3(-dodgeForceValue, dodgeForce.y, 0);
                }

                playerBody.velocity = new Vector3(0, 0, 0);
                playerBody.AddForce(dodgeForce);
                Invoke(nameof(RestoreDodge), dodgeTime);
                //Debug.Log("Dodge called");
            }
        }

    }

    public void RestoreDodge()
    {
        //canMove = true;
        plyerAnimator.SetBool("Dodging", false);
        canDodge = true;
        playerCanControl = true;
    }
    public void SetCanMove(bool canMoveNow)
    {
        canMove = canMoveNow;
    }

    private void MovePlayer()
    {
        if (canMove == true )
        {
            
            Vector3 movePlayer = playerMovementInput.normalized * speed;
            //Vector3 movePlayer = (transform.TransformDirection(playerMovementInput)) * speed;
            //Debug.Log(movePlayer);
            //movePlayer = movePlayer.normalized ;
            Vector3 playerVelocity = new Vector3(movePlayer.x, playerBody.velocity.y, movePlayer.z);

            playerBody.velocity = playerVelocity;
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
            playerHitSound.Post(gameObject);
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
        gameObject.GetComponent<Pause>().canBePaused = false;
        canMove = false;
        deathCam.Priority = 21;
        deathUI.SetActive(true);
        this.GetComponent<Renderer>().sortingOrder = 1;
        deathSound.Post(gameObject);
        mainCamera = GameObject.Find("Main Camera (1)");
        deathSwitch.SetValue(mainCamera.gameObject);
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
            speedRef = speed;
        }
    }

    public void AddSpeed(float additionalSpeed)
    {
        //if (spedUp == false)
        //{
        //    speed *= 1.5f;
        //    spedUp = true;
        //}

        speed += additionalSpeed;
        speedRef = speed;
    }


    public void DownAttack()
    {
        if(plyerAnimator.GetFloat("FacingUp") == -1)
            slashDown.SetActive(true);
    }
    public void DownAttackDone()
    {
        slashDown.SetActive(false);
    }

    //public void MovementSpeedIfAttack(bool makeBigger)
    //{
    //    if (makeBigger)
    //        speed *= 2;
    //    else
    //        speed *= 0.5f;
    //}

    public void HalfSpeed()
    {
        speed *= 0.5f;
    }

    public void SetSpeedNormal()
    {
        speed = speedRef;
    }
}
