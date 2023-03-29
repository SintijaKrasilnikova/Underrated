using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    public GameObject healthVFX;
    public GameObject healthPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(healthVFX, healthPos.transform.position, healthPos.transform.rotation);
        }
    }
}
