using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerMove = collision.GetComponent<PlayerMovement>();

            playerMove.SpeedUp();
            this.gameObject.SetActive(false);

        }
    }
}
