using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    private PortalEnd portalEndRef;

    public GameObject pickupRef;
    public BoxCollider col;
    bool hasBeenPickedUp = false;

    public AK.Wwise.Event pickupSoundSpeed;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerMove = collision.GetComponent<PlayerMovement>();
            var playerCards = collision.GetComponent<Card_Numbers>();

            pickupRef = GameObject.FindGameObjectWithTag("PickupRef");
            //portalEndRef = GameObject.FindGameObjectWithTag("Portal").GetComponent<PortalEnd>();
            //portalEndRef.SetHasAnyCards(false);

            //playerMove.SpeedUp();
            playerCards.speedCard++;
            cardOver.halfCards.Add(0);
            pickupSoundSpeed.Post(gameObject);

            

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

    public void SpawnCard()
    {
        col.enabled = false;
    }

    public void EnableCollision()
    {
        col.enabled = true;
    }
}
