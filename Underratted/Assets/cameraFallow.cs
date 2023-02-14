using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFallow : MonoBehaviour
{
    //https://www.youtube.com/watch?v=MFQhpwc6cKE
    //https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html


    public Transform target;

    
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    public Vector3 cameraOffset;

    //runs after the update
    void LateUpdate()
    {
        Vector3 wantedPosition = target.position + cameraOffset;
       // Vector3 smoothedPosition = Vector3.Lerp(transform.position, wantedPosition, smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, wantedPosition, ref velocity, smoothTime);

        transform.position = smoothedPosition;
    }
}
