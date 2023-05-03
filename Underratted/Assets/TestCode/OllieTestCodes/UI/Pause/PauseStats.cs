using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseStats : MonoBehaviour
{
    public GameObject player;
    public int playerHealth;
    public float playerAttack;
    public float playerSpeed;
    public TextMeshProUGUI tmpText;

    public bool isHealth = false;
    public bool isAttack = false;
    public bool isSpeed = false;
    // Start is called before the first frame update
    void Start()
    {
        tmpText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>().maxHealth;
        playerAttack = player.GetComponent<AttackTimer>().baseDamage;
        playerSpeed = player.GetComponent<PlayerMovement>().speed;

        if (isHealth)
        {
            tmpText.text = playerHealth.ToString();
        }
        if (isAttack)
        {
            tmpText.text = playerAttack.ToString();
        }
        if (isSpeed)
        {
            tmpText.text = playerSpeed.ToString();
        }
    }
}
