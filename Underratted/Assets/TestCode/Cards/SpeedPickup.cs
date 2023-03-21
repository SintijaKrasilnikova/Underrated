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
            var playerCards = collision.GetComponent<Card_Numbers>();

            playerMove.SpeedUp();
            playerCards.speedCard++;
            this.gameObject.SetActive(false);

        }
    }
}
