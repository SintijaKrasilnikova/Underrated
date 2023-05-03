using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoCardNextScene : MonoBehaviour
{
    public bool isUnlockScene = false;
    public PortalEnd portalRef;
    public bool isLevel2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isUnlockScene)
            {
                portalRef.LoadCrafting();
            }
            else
            {
                if (isLevel2)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

            }

        }
    }
}
