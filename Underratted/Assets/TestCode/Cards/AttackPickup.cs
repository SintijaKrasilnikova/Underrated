using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPickup : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public float increaseAmount = 2f;

    public GameObject pickupRef;
    public BoxCollider col;
    bool hasBeenPickedUp = false;
    public AK.Wwise.Event pickupSoundAttack;
    private PortalEnd portalEndRef;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerAttack = collision.GetComponent<AttackTimer>();
            var playerCards = collision.GetComponent<Card_Numbers>();

            pickupRef = GameObject.FindGameObjectWithTag("PickupRef");
            //portalEndRef = GameObject.FindGameObjectWithTag("Portal").GetComponent<PortalEnd>();
            //portalEndRef.SetHasAnyCards(false);

            //playerAttack.IncreaseBaseDamage(increaseAmount);
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
