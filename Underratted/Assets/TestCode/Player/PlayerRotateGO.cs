using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateGO : MonoBehaviour
{

    //Rotates the gameobject based on where the player is facing

    private Vector3 startLocalOffset;
    private Animator animator;
    private bool inFront;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>(false);
        startLocalOffset = this.transform.localPosition;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetFloat("FacingRight") == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            //this.transform.Rotate(0, 0, 0);
            // this.transform.localPosition = new Vector3(Mathf.Abs(startLocalOffset.x), startLocalOffset.y, startLocalOffset.z);

        }
        else if (animator.GetFloat("FacingRight") == -1)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            //this.transform.Rotate(0, 180, 0);
            //this.transform.localPosition = new Vector3(-Mathf.Abs(startLocalOffset.x), startLocalOffset.y, startLocalOffset.z);
        }

        if (animator.GetFloat("FacingUp") == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, -90, 0);
            //this.transform.Rotate(0, -90, 0);
            //this.transform.localPosition = new Vector3(startLocalOffset.z, startLocalOffset.y, Mathf.Abs(startLocalOffset.x));
            // Debug.Log("Set to up");
        }
        else if (animator.GetFloat("FacingUp") == -1)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
            //this.transform.Rotate(0, 90, 0);
            //this.transform.localPosition = new Vector3(startLocalOffset.z, startLocalOffset.y, -Mathf.Abs(startLocalOffset.x));
            // Debug.Log("Set to down");
        }

        //if (animator.GetFloat("FacingUp") == 1 && animator.GetFloat("FacingRight") == 1)
        //{
        //    this.transform.rotation = Quaternion.Euler(0, 135, 0);
        //}
    }
}
