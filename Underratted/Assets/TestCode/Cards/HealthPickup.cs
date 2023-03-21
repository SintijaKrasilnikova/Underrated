using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<PlayerHealth>();
            var playerCards = collision.GetComponent<Card_Numbers>();

            playerHealth.AddHealth();
            playerCards.healthCard++;
            this.gameObject.SetActive(false);

        }
    }
}
