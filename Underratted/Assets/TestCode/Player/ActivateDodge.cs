using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDodge : MonoBehaviour
{
    //[SerializeField] private PlayerMovement movement;

    [SerializeField] private CardOverseer overseer;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //movement.SetDodgeIsAvailable();
            overseer.DodgeActive = true;
        }
    }
}
