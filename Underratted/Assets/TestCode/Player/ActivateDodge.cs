using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDodge : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            movement.SetDodgeIsAvailable();
        }
    }
}
