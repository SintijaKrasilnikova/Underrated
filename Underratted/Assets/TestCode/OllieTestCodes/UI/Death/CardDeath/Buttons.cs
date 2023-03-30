using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject confirmScreen;
    public bool isCard = false;

    public bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        nextButton.GetComponent<Button>().Select();

        if (isCard)
        {
            confirmScreen.SetActive(true);
            selected = true;
        }
        else
        {
            confirmScreen.SetActive(false);
            selected = false;
        }
    }
}
