using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyParent : MonoBehaviour
{
    public GameObject dummy;
    public GameObject bloodSplat;
    public GameObject bloodSpray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            Instantiate(bloodSpray, dummy.transform.position, dummy.transform.rotation);
            Instantiate(bloodSplat, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(dummy);
        }
    }
}
