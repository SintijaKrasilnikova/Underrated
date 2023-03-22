using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimEvents : MonoBehaviour
{
    public BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCard()
    {
        col.enabled = false;
    }

    public void EnableCollision()
    {
        col.enabled = true;
    }
}
