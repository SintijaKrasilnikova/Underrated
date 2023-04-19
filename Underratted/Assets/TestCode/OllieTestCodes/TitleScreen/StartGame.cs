using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;

    private int LoadNextLevel;
    public MixAnim animCheck;
    public bool isStartScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.Space) && isStartScreen))
        {
            if (cardOver.firstRun)
            {
                cardOver.firstRun = false;
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
            }

        }
        else if (Input.GetKey(KeyCode.Space) && animCheck.canLoadNextLevel)
        {
        
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.B))
        {
            SceneManager.LoadScene(4);
        }
    }
}
