using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedHalfCard : MonoBehaviour
{
    [SerializeField] private CardOverseer cardOver;
    public Animator animator;
    public Sprite[] sprites;
    public int cardRef;
    public int cardID;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = sprites[cardOver.halfCards[cardID]];
    }
}
