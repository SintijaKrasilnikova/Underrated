using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject resumeButton;
    public EventSystem eventSystems;
    public AK.Wwise.Event InventoryOpenClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseAction();
            }
        }
    }

    public void Resume()
    {
        InventoryOpenClose.Post(gameObject);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseAction()
    {
        InventoryOpenClose.Post(gameObject);
        eventSystems.SetSelectedGameObject(resumeButton);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
