using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseNextPage : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public int cardLimit;
    public GameObject nextPage;
    public GameObject currentPage;

    public Image buttonImage;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cardLimit < cardOver.fullCards.Count)
        {
            button.enabled = true;
            buttonImage.enabled = true;
        }
        else
        {
            button.enabled = false;
            buttonImage.enabled = false;
        }
    }

    public void ButtonClicked()
    {
        currentPage.SetActive(false);
        nextPage.SetActive(true);
    }
}
