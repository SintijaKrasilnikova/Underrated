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
    public float attackDistance = 1f;


    public Transform target;
    private Vector3 enemyMoveDirection;
    private Vector3 startPosition;
    public bool isHunting = false;

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

            // OR for a square range, AND for a circle
            if (Mathf.Abs(target.position.x + attackDistance - startPosition.x) < enemyRadius && Mathf.Abs(target.position.z + attackDistance - startPosition.z) < enemyRadius)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                Vector3 enemyToPlayer = new Vector3(direction.x, 0, direction.z);
                
                EnemyMove(enemyToPlayer);

                isHunting = true;
            }
            else
            {
                Vector3 backDirection = (startPosition - transform.position).normalized;
                Vector3 enemyToStart = new Vector3(backDirection.x, 0, backDirection.z);

                EnemyMove(enemyToStart);
                isHunting = false;
            }
        }
    }

    private void EnemyMove(Vector3 currentDirection)
    {
        if (target != null)
        {
            rigidBody.velocity = currentDirection * enemyMoveSpeed * 100 * Time.deltaTime;
        }
    }

}
