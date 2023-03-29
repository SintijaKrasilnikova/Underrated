using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // https://www.youtube.com/watch?v=ZExSz7x69j8

    [SerializeField] float enemyMoveSpeed = 5f;

    public Rigidbody rigidBody;
    public float enemyRadius = 5f;

    //distance at which enemy stops chasing the player and goes for an attack
    public float safeDistance = 3f;
   // private Vector3 safeDistanceVector = new Vector3(safeDistance, 0, safeDistance);

    public Transform target;
    public Vector3 enemyMoveDirection;
    private Vector3 startPosition;
    public bool isHunting = false;

    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        enemyAnimator.SetBool("Hunting", isHunting);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            // OR for a square range, AND for a circle
            if (Mathf.Abs(target.position.x - startPosition.x) < enemyRadius && Mathf.Abs(target.position.z - startPosition.z) < enemyRadius)
            {
                //if (Mathf.Abs(target.position.x - safeDistance - startPosition.x) < enemyRadius && Mathf.Abs(target.position.z - safeDistance - startPosition.z) < enemyRadius)
                //{
                //    isHunting = false;
                //    enemyAnimator.SetBool("Hunting", isHunting);
                //}
                //else
                //{
                    Vector3 direction = (target.position - transform.position).normalized;
                    Vector3 enemyToPlayer = new Vector3(direction.x, 0, direction.z);

                    EnemyMove(enemyToPlayer);

                    isHunting = true;
                    enemyAnimator.SetBool("Hunting", isHunting);
                //}
            }
            else
            {
                Vector3 backDirection = (startPosition - transform.position).normalized;
                Vector3 enemyToStart = new Vector3(backDirection.x, 0, backDirection.z);

                EnemyMove(enemyToStart);
                isHunting = false;
                enemyAnimator.SetBool("Hunting", isHunting);
            }
        }

        
    }

    private void EnemyMove(Vector3 currentDirection)
    {
        if (target != null)
        {
            rigidBody.velocity = currentDirection * enemyMoveSpeed * 100 * Time.deltaTime;


            //if (currentDirection.sqrMagnitude >= 0.01)
            //{
                //left right for animation
                //if (currentDirection.x < 0)// && Input.GetAxis("Vertical") ==0)
                if (currentDirection.x < 0 && currentDirection.x < currentDirection.z)// && Input.GetAxis("Vertical") ==0)
                {
                    enemyAnimator.SetFloat("FacingUp", 0);
                    enemyAnimator.SetFloat("FacingRight", -1); //left
                }
                else if (currentDirection.x <  0 && currentDirection.x > currentDirection.z)
                {
                    enemyAnimator.SetFloat("FacingRight", 0);
                    enemyAnimator.SetFloat("FacingUp", -1); //down
                 }

                //up down for animation
                if (currentDirection.x > 0 && currentDirection.x > currentDirection.z)// && Input.GetAxis("Horizontal") == 0)
                {
                //enemyAnimator.SetFloat("FacingRight", 0);
                //enemyAnimator.SetFloat("FacingUp", -1); //down

                    enemyAnimator.SetFloat("FacingUp", 0);
                    enemyAnimator.SetFloat("FacingRight", 1); //right
                 }
                else if (currentDirection.x > 0 && currentDirection.x < currentDirection.z)
                {
                    enemyAnimator.SetFloat("FacingRight", 0);
                    enemyAnimator.SetFloat("FacingUp", 1); //up
                }


            //if (currentDirection.x < 0)// && Input.GetAxis("Vertical") ==0)
            //{
            //    enemyAnimator.SetFloat("FacingUp", 0);
            //    enemyAnimator.SetFloat("FacingRight", -1); //left
            //}
            //    else if (currentDirection.x > 0)
            //{
            //    enemyAnimator.SetFloat("FacingUp", 0);
            //    enemyAnimator.SetFloat("FacingRight", 1); //right
            //}

            ////up down for animation
            //if (currentDirection.z < 0)// && Input.GetAxis("Horizontal") == 0)
            //{
            //    enemyAnimator.SetFloat("FacingRight", 0);
            //    enemyAnimator.SetFloat("FacingUp", -1); //down
            //}
            //else if (currentDirection.z > 0)
            //{
            //    enemyAnimator.SetFloat("FacingRight", 0);
            //    enemyAnimator.SetFloat("FacingUp", 1); //up
            //}
            //// }
        }
    }

}
