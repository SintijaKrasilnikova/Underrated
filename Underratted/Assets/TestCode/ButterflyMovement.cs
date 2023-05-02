using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{
    /*[SerializeField] */
    private float butterflySpeed = 1f;
    /*[SerializeField] */
    private float movementDist = 6f;
    private float movementDistY = 1.5f;
    [SerializeField] private bool movingRight = true;
    [SerializeField] private bool movingUp = true;
    private float startPosition;
    private float startPositionY;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        startPositionY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (movingRight == true)
        {
            if (currentPos.x < startPosition + movementDist)
            {
                transform.position = new Vector3(currentPos.x + (Time.deltaTime * butterflySpeed), currentPos.y, currentPos.z);
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            if (currentPos.x > startPosition - movementDist)
            {
                transform.position = new Vector3(currentPos.x - (Time.deltaTime * butterflySpeed), currentPos.y, currentPos.z);
            }
            else
            {
                movingRight = true;
            }

        }

        currentPos = transform.position;

        if (movingUp == true)
        {
            if (currentPos.y < startPositionY + movementDistY)
            {
                transform.position = new Vector3(currentPos.x, currentPos.y + (Time.deltaTime * butterflySpeed), currentPos.z);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (currentPos.y > startPositionY - movementDistY)
            {
                transform.position = new Vector3(currentPos.x, currentPos.y - (Time.deltaTime * butterflySpeed), currentPos.z);
            }
            else
            {
                movingUp = true;
            }

        }

    }
}

