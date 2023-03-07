using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardRandomDropper : MonoBehaviour
{

    //private bool spinAlreadyDropped = false;
    public GameObject spinCardRef = default;
    public SpinPickup spinRef = default;
    public AttackTimer attackTimer;


    void Start()
    {
    }


    public void chanceToDropCard(int howLikely)
    {
        //range from 1 to 100
        int randomChance = Random.Range(1, 100);

        //if random number is lower then the drop percantage
        if (randomChance < howLikely && spinRef.getSpinPickedUp() == false)
        {
            //drop the card
            spinRef.setSpinPickedUp(true);
            spinCardRef.transform.position = gameObject.transform.position;
            spinCardRef.SetActive(true);
            //attackTimer.setSpinActive(true);
        }


    }
}
