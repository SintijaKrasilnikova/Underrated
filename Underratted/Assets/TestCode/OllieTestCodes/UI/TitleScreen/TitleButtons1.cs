using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons1 : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    public GameObject controls;
    public GameObject credits;
    public bool controlsShown = false;
    public bool creditsShown = false;
    public GameObject MainCamera;
    [SerializeField]
    private AK.Wwise.Switch creditsSwitch;
    [SerializeField]
    private AK.Wwise.Switch titleSwitch;
    public AK.Wwise.Event musicStop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (credits.activeSelf)
        {
            creditsShown = true;
        }
        if (controls.activeSelf)
        {
            controlsShown = true;
        }


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(controlsShown == true)
            {
                controlsShown = false;
                controls.SetActive(false);
            }

            if(creditsShown == true)
            {
                creditsShown = false;
                credits.SetActive(false);
                MainCamera = GameObject.Find("Main Camera");
                titleSwitch.SetValue(MainCamera.gameObject);
            }
        }
    }

    public void StartGame()
    {
        if(!creditsShown || !controlsShown)
        {
            if (cardOver.firstRun)
            {
                MainCamera = GameObject.Find("Main Camera");
                musicStop.Post(MainCamera);
                SceneManager.LoadScene(2);
            }
            else
            {
                MainCamera = GameObject.Find("Main Camera");
                musicStop.Post(MainCamera);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void ShowControls()
    {
        if (!creditsShown)
        {
            controls.SetActive(true);
            controlsShown = true;
        }
    }

    public void ShowCredits()
    {
        if (!controlsShown)
        {
            credits.SetActive(true);
            creditsShown = true;
            MainCamera = GameObject.Find("Main Camera");
            creditsSwitch.SetValue(MainCamera.gameObject);
        }

    }

    public void QuitGame()
    {
        if(!creditsShown || !controlsShown)
        {
            Application.Quit();
        }
    }
}