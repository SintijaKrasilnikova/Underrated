using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillDescriptions : MonoBehaviour, IEventSystemHandler, ISelectHandler
{
    [SerializeField] private CardOverseer cardOver;

    public string[] strings;
    public int descriptionID;

    public TextMeshProUGUI skillDesc;
    public EventSystem eventSystem;

    public Animator animator;

    public bool isSkill2Above = false;
    Image skill2Image;
    public Color skill2Color;
    // Start is called before the first frame update
    void Start()
    {
        if (cardOver.DodgeActive && descriptionID == 1)
        {
            descriptionID = 2;
        }
        else
        {
            if (isSkill2Above)
            {
                skill2Image = GetComponent<Image>();
                skill2Image.color = skill2Color;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnSelect(BaseEventData eventData)
    {
        skillDesc.text = strings[descriptionID];

        if(descriptionID == 0)
        {
            animator.SetTrigger("Spin");
        }
        if(descriptionID == 2)
        {
            animator.SetTrigger("Dodge");
        }

    }
}
