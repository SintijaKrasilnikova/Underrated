using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<PlayerHealth>();
            //var playerCards = collision.GetComponent<Card_Numbers>();

            playerHealth.GainHealthFromPickup();
            Destroy(this.gameObject);

            //col.enabled = false;
            //hasBeenPickedUp = true;
        }
    }
}
