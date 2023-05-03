using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class HighlightButtonMove : MonoBehaviour, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
    public RectTransform highlightRect;
    public RectTransform thisRect;

    public GameObject highlight;

    public float xOffset;
    public float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        thisRect = GetComponent<RectTransform>();
        highlightRect = highlight.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        highlight.SetActive(true);
        highlightRect.anchoredPosition = thisRect.anchoredPosition;

        //highlightRect.anchoredPosition = Vector2.Lerp(highlightRect.anchoredPosition, thisRect.anchoredPosition, Time.deltaTime * 2);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        highlight.SetActive(false);
    }
}
