using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemy : MonoBehaviour
{
    GameObject arenaDataRef;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        arenaDataRef = GameObject.FindGameObjectWithTag("ArenaHandler");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void arenaKill()
    {
        arenaDataRef.GetComponent<ArenaActivate>().enemiesKilled++;
    }
}
