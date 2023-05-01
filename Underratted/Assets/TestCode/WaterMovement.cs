using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{

    /*[SerializeField] */private float waterSpeed = 1f;
    /*[SerializeField] */private float movementDist = 6f;
    [SerializeField] private bool movingRight = true;
    private float startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (movingRight == true)
        {
            if(currentPos.x < startPosition + movementDist)
            {
                transform.position = new Vector3(currentPos.x + (Time.deltaTime * waterSpeed), currentPos.y, currentPos.z);
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
                transform.position = new Vector3(currentPos.x - (Time.deltaTime * waterSpeed), currentPos.y, currentPos.z);
            }
            else
            {
                movingRight = true;
            }

        }
        
    }
}
