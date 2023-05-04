using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArenaActivate : MonoBehaviour
{
    public GameObject enemies;
    public GameObject walls;
    public GameObject card;
    public GameObject arenaUI;

    public TextMeshProUGUI killedText;
    public int enemiesKilled = 0;
    public int goalKills;
    bool activateArena = false;

    public AK.Wwise.Event arenaSound;
    [SerializeField] AK.Wwise.Switch arenaSwitch;
    [SerializeField] AK.Wwise.Switch forestSwitch;
    public GameObject mainCamera;
    public bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killedText.text = enemiesKilled.ToString();
        if (!card.activeSelf && activateArena == false)
        {
            arenaSound.Post(gameObject);
            mainCamera = GameObject.Find("Main Camera (1)");
            arenaSwitch.SetValue(mainCamera.gameObject);
            arenaUI.SetActive(true);
            enemies.SetActive(true);
            walls.SetActive(true);
            activateArena = true;
        }

        if(activateArena && enemiesKilled > goalKills)
        {
            arenaUI.SetActive(false);
            walls.SetActive(false);
            if(hasRun==false)
            {
                arenaSound.Post(gameObject);
                mainCamera = GameObject.Find("Main Camera (1)");
                forestSwitch.SetValue(mainCamera.gameObject);
                hasRun = true;
            }
        }
    }
}
