using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    [SerializeField] Light lightRef;
    [SerializeField] Color wantedColor;
    private bool shouldChangeColor = false;
    private bool colourChanged = false;
    private bool changeToDark = true;
    private Color colorAtStart;
    // Start is called before the first frame update
    void Start()
    {
        //lightRef.color = new Color(0.2f, 0.2f, 0.7f);
        //colorAtStart = lightRef.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldChangeColor)
        {
            //lightRef.color = wantedColor;
            //colourChanged = true;
            ChangeLightColour(changeToDark);

        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            changeToDark = true;
            colorAtStart = lightRef.color;
            shouldChangeColor = true;
            colourChanged = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player") && colourChanged == true)
        {
            changeToDark = false;
            shouldChangeColor = true;
        }
    }

    public void ChangeLightColour(bool toDark)
    {
        if(toDark)
        {
            if (lightRef.color.r > 0.3)
                lightRef.color -= (Color.white / 2.0f) * Time.deltaTime;
            else
                shouldChangeColor = false;
        }
        else
        {
            if (lightRef.color.r < 1)
                lightRef.color += (Color.white / 2.0f) * Time.deltaTime;
            else
                shouldChangeColor = false;
        }

    }
}
