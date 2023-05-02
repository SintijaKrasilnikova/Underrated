using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTongue : MonoBehaviour
{

    private GameObject tongueRight;
    private GameObject tongueLeft;
    private Animator animator;

    private float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //tongueRight = GameObject.FindGameObjectWithTag("TRight");
        tongueRight = transform.GetChild(3).gameObject;
        tongueLeft = transform.GetChild(4).gameObject;

        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTongueRight()
    {
        if (animator.GetBool("Attacking") == true)
        {
            tongueRight.SetActive(true);
            Invoke(nameof(TurnOffTongue), 1f);

        }
    }

    public void ActivateTongueLeft()
    {
        if (animator.GetBool("Attacking") == true)
        {
            tongueLeft.SetActive(true);
            Invoke(nameof(TurnOffTongue), 1f);
        }
    }

    public void TurnOffTongue()
    {
        tongueRight.SetActive(false);
        tongueLeft.SetActive(false);
    }
}
