using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private int LoadNextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
<<<<<<< Updated upstream
=======
        else if (Input.GetKey(KeyCode.Space) && animCheck.canLoadNextLevel)
        {
        
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.B))
        {
            SceneManager.LoadScene(4);
        }
>>>>>>> Stashed changes
    }
}
