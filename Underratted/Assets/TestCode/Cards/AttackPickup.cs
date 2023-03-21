using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPickup : MonoBehaviour
{
    public int increaseAmount = 2;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerAttack = collision.GetComponent<AttackTimer>();
            var playerCards = collision.GetComponent<Card_Numbers>();

            playerAttack.IncreaseBaseDamage(increaseAmount);
            playerCards.attackCard++;
            this.gameObject.SetActive(false);

        }
    }
}
