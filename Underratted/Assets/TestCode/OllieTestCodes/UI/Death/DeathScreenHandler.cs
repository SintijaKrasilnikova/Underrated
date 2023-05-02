using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeathScreenHandler : MonoBehaviour
{
    public GameObject fadeOut;
    public AK.Wwise.Event restartPressed;
    public EventSystem eventSystem;

    public GameObject deathCardSelect;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            eventSystem.firstSelectedGameObject = deathCardSelect;
            restartPressed.Post(gameObject);
            fadeOut.SetActive(true);
        }
    }
}
