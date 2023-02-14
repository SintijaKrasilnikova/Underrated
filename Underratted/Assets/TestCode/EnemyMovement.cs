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
    //Transform target;

    public Transform target;
    private Vector3 enemyMoveDirection;
    public Vector3 startPosition;


    //private void Awake()
    //{
    //    rigidBody = GetComponent<Rigidbody2D>();
    //}

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //Vector3 direction = (target.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // rigidBody.rotation.y = angle;
            // Vector3 distance = Vector3.Distance(transform.position, startPosition);
            //Vector3.Distance(transform.position, startPosition);

            //if (Mathf.Abs(Vector3.Distance(startPosition, transform.position)) < enemyRadius)
            //{
            //    Vector3 direction = (target.position - transform.position).normalized;
            //    enemyMoveDirection = new Vector3(direction.x, 0, direction.z);


            //    //Vector3 enemyToPlayer = new Vector3(direction.x, 0, direction.z);
            //    //rigidBody.velocity = enemyToPlayer * enemyMoveSpeed * Time.deltaTime;
            //}
            //else
            //{
            //    Vector3 backDirection = (startPosition - transform.position).normalized;
            //    enemyMoveDirection = new Vector3(backDirection.x, 0, backDirection.z);

            //    //Vector3 enemyToStart = new Vector3(backDirection.x, 0, backDirection.z);
            //    //rigidBody.velocity = enemyToStart * enemyMoveSpeed * Time.deltaTime;
            //}


            if (Mathf.Abs( transform.position.x - startPosition.x) < enemyRadius || Mathf.Abs(transform.position.z - startPosition.z) < enemyRadius)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                enemyMoveDirection = new Vector3(direction.x, 0, direction.z);
            }
            else
            {
                Vector3 backDirection = (startPosition - transform.position).normalized;
                enemyMoveDirection = new Vector3(backDirection.x, 0, backDirection.z);
            }

            enemyMove();
            //enemyMoveDirection = new Vector3(direction.x, 0, direction.z);
        }
    }

    //private void FixedUpdate()
    //{
    //    if (target != null)
    //    {
    //        rigidBody.velocity = enemyMoveDirection * enemyMoveSpeed * Time.deltaTime;
    //    }
    //}

    private void enemyMove()
    {
        if (target != null)
        {
            rigidBody.velocity = enemyMoveDirection * enemyMoveSpeed * Time.deltaTime;
        }
    }

    //void LateUpdate()
    //{

    //    if (target != null)
    //    {
    //        rigidBody.velocity = enemyMoveDirection * enemyMoveSpeed * Time.deltaTime;
    //    }

    //}
}
