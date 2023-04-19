using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaActivate : MonoBehaviour
{
    public GameObject enemies;
    public GameObject walls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            enemies.SetActive(true);
            walls.SetActive(true);
        }
    }
}
