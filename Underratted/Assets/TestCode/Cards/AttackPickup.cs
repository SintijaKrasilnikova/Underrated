using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPickup : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public int increaseAmount = 2;

    public GameObject pickupRef;
    public BoxCollider col;
    bool hasBeenPickedUp = false;
    public AK.Wwise.Event pickupSoundAttack;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerAttack = collision.GetComponent<AttackTimer>();
            var playerCards = collision.GetComponent<Card_Numbers>();

            playerAttack.IncreaseBaseDamage(increaseAmount);
            playerCards.attackCard++;
            cardOver.halfCards.Add(1);
            pickupSoundAttack.Post(gameObject);

            col.enabled = false;
            hasBeenPickedUp = true;
        }
    }

    private void Update()
    {
        if (hasBeenPickedUp)
        {
            gameObject.transform.position = pickupRef.transform.position;
            StartCoroutine(PickedUp(1.5f));
        }
    }

    IEnumerator PickedUp(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }

    
}
