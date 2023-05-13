using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeStartCard : MonoBehaviour
{
    //private GameObject cardSpawnLocation;
    [SerializeField] private CardRandomDropper dropper;
    //[SerializeField] private bool startActive
    private BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        //cardSpawnLocation = GameObject.FindGameObjectWithTag("CardPoint");
        dropper.StartRandomCard(this.gameObject.transform.position);
        collider = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}