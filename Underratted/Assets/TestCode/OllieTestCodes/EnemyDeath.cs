using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject bloodSplat;
    public GameObject bloodSpray;
    public GameObject bloodPos;

    bool canMakeBlood = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        if (canMakeBlood)
        {
            Instantiate(bloodSpray, bloodPos.transform.position, bloodPos.transform.rotation);
            Instantiate(bloodSplat, bloodPos.transform.position, bloodPos.transform.rotation);
            canMakeBlood = false;
        }
    }
}
