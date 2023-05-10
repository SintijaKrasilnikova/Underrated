using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    public int wantedFPS = 60;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = wantedFPS;
    }

    void Update()
    {
        if (Application.targetFrameRate != wantedFPS)
            Application.targetFrameRate = wantedFPS;
    }
}
