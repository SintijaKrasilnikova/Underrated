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
        //when enemy dies, spray blood and spawn a pool of blood
        if (other.gameObject.CompareTag("AttackArea"))
        {
            Instantiate(bloodSpray, dummy.transform.position, dummy.transform.rotation);
            Instantiate(bloodSplat, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(dummy);
        }
    }
}
