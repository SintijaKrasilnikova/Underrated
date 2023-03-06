using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Cinemachine_Shake : MonoBehaviour
{
    public static Cinemachine_Shake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    //get the instance and components of the cam
    private void Awake()
    {
        Instance = this; 
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    //shake the camera when called
    public void ShakeCam (float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    //reduce the shake over time
    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                    Mathf.Lerp(startingIntensity, 0f, (1- (shakeTimer / shakeTimerTotal)));
            }
        }
    }

}
