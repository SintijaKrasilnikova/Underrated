using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
    public GameObject highlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeselect(BaseEventData eventData)
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        highlight.transform.position = gameObject.transform.position;
    }
}
