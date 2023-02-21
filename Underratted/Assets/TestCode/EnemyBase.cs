using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyBase : MonoBehaviour
{

    
    //player tranform
    public Transform playerTransform;
    //player health component
    public health playerHealth;

    
    public Animator enemyAnimator;
    public NavMeshAgent enemyAI;
    public Rigidbody enemyRigidBody;

    public bool shouldWander = true;
    public bool shouldHunt = true;
    public float huntingDistance = 5f;
    

    private bool isHunting = false;
    private Vector3 startPosition;
    
    //public BoxCollider enemyCollsisionBox;// = gameOunity inibject.AddComponent<BoxCollider>();

    //private bool deathAnimation = false;

    //Base enemey class that the enemies can inherit from and get the basic functions that all enemies share
    // Start is called before the first frame update
    public void Start()
    {
        //get the player health component at the start of the game
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<health>();
        //playerHealth = GameObject.Find("Player").GetComponent<health>();

        ////get the animator from the child
        //enemyAnimator = GetComponent<Animator>();


        ////add animator component
        //this.gameObject.AddComponent<Animator>();
        //enemyAnimator = GetComponent<Animator>();

        ////NAV component for enemy to avoid absticles while fallowing the player
        //this.gameObject.AddComponent<NavMeshAgent>();
        //enemyAI = GetComponent<NavMeshAgent>();

        ////body
        //this.gameObject.AddComponent<Rigidbody>();
        //enemyRigidBody = GetComponent<Rigidbody>();

        ////collision box
        //this.gameObject.AddComponent<BoxCollider>();
        //enemyCollsisionBox = GetComponent<BoxCollider>();

        startPosition= transform.position;
    }



    // Update is called once per frame
    public void Update()
    {
        
    }

    //basic damage function to the player
    protected void DamagePlayer(int damageAmount)
    {
        //decrease health
        playerHealth.currentHealth -= damageAmount;

        //deleting the game object is done in the health component

    }

    protected void huntPlayer()
    {

        if (shouldHunt == true && Mathf.Abs(playerTransform.position.x - startPosition.x) < huntingDistance && Mathf.Abs(playerTransform.position.z - startPosition.z) < huntingDistance)
        {
            enemyAI.destination = playerTransform.position;
            isHunting = true;
        }
        else //return to the start position
        {
            isHunting = false;

        }

    }


    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.tag == "Player")
    //    {

    //        var healthComp = collision.GetComponent<health>();
    //        if (healthComp != null)
    //        {
    //            Debug.Log("Health decreased");
    //            healthComp.TakeDamage(damage);
    //        }
    //    }

    //}

}
