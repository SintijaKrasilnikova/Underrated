using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadoutPlayerStats : MonoBehaviour
{
    public TextMeshProUGUI statText;
    public float statNumb;
    // Start is called before the first frame update
    void Start()
    {
        statText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        statText.text = statNumb.ToString();
    }
}
