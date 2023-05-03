using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleScreenStart : MonoBehaviour
{
    public Button startButton;
    public EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        startButton.Select();
        eventSystem.firstSelectedGameObject = startButton.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
