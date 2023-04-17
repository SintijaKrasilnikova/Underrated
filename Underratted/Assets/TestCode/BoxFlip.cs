using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFlip : MonoBehaviour
{

    //public bool forAttackArea = false;
    private Vector3 startLocalOffset;

    private BoxCollider boxCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        animator = gameObject.GetComponentInParent<Animator>(false);
       
        //if(forAttackArea == false)
        //{
        startLocalOffset = boxCollider.transform.localPosition;
       // }

    }

    // Update is called once per framea
    void Update()
    {

        if (animator.GetFloat("FacingRight") == 1)
        {
            boxCollider.transform.localPosition = new Vector3(Mathf.Abs(startLocalOffset.x), startLocalOffset.y, startLocalOffset.z);
            //boxCollider.transform.localPosition = new Vector3(Mathf.Abs(startLocalOffset.x), startLocalOffset.y, startLocalOffset.z);

        }
        else if (animator.GetFloat("FacingRight") == -1)
        {
            boxCollider.transform.localPosition = new Vector3(-Mathf.Abs(startLocalOffset.x), startLocalOffset.y, startLocalOffset.z);

            //boxCollider.transform.localPosition = new Vector3(-Mathf.Abs(startLocalOffset.x), startLocalOffset.y, startLocalOffset.z);
        }

        //if (animator.GetFloat("FacingUp") == 1)
        //{
        //    //boxCollider.transform.localPosition = new Vector3(startLocalOffset.z, startLocalOffset.y, -Mathf.Abs(startLocalOffset.x));

        //    boxCollider.transform.localPosition = new Vector3(startLocalOffset.z, startLocalOffset.y, Mathf.Abs(startLocalOffset.x));
        //    // Debug.Log("Set to up");
        //}
        //else if (animator.GetFloat("FacingUp") == -1)
        //{
        //    //boxCollider.transform.localPosition = new Vector3(startLocalOffset.z, startLocalOffset.y, Mathf.Abs(startLocalOffset.x));

        //    boxCollider.transform.localPosition = new Vector3(startLocalOffset.z, startLocalOffset.y, -Mathf.Abs(startLocalOffset.x));
        //    // Debug.Log("Set to down");
        //}
       
    }

}
