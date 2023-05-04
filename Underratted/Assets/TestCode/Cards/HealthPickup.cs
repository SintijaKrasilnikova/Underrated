using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public GameObject pickupRef;
    public BoxCollider col;
    bool hasBeenPickedUp = false;
    public AK.Wwise.Event pickupSoundHealth;
    private PortalEnd portalEndRef;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<PlayerHealth>();
            var playerCards = collision.GetComponent<Card_Numbers>();

            pickupRef = GameObject.FindGameObjectWithTag("PickupRef");
            //portalEndRef = GameObject.FindGameObjectWithTag("Portal").GetComponent<PortalEnd>();
            //portalEndRef.SetHasAnyCards(false);

            //playerHealth.AddHealth();
            playerCards.healthCard++;
            cardOver.halfCards.Add(2);
            pickupSoundHealth.Post(gameObject);

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
