using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPickup : MonoBehaviour
{
    public bool spinPickedUp = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<AttackTimer>().setSpinActive(true);


            this.gameObject.SetActive(false);
        }
    }

    public void setSpinPickedUp(bool isPicked)
    {
        spinPickedUp = isPicked;
    }

    public bool getSpinPickedUp()
    {
        return spinPickedUp;
    }
}
