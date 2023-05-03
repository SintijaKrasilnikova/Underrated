using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoData : MonoBehaviour
{
    public VideoPlayer player;

    public PortalEnd portal;

    // Start is called before the first frame update
    void Start()
    {
        player.loopPointReached += portal.VideoLoadCrafting;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
