using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitButtonPause : MonoBehaviour
{
    public GameObject quitCheck;
    public Pause pauseScript;
    public EventSystem eventSystem;

    public GameObject yesButton;
    public GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateQuit()
    {
        quitCheck.SetActive(true);
        eventSystem.SetSelectedGameObject(yesButton);
    }
    public void deactivateQuit()
    {
        quitCheck.SetActive(false);
        eventSystem.SetSelectedGameObject(quitButton);
    }
    public void Quit()
    {
        pauseScript.Resume();
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        pauseScript.Resume();
    }
}
