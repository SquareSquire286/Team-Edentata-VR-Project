using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoButtonEvent : AbstractButtonEvent
{
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    public override void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public override void ExecuteEvent()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();

        else videoPlayer.Play();
    }

    public override void StopEvent()
    {
        videoPlayer.Pause();
    }
}
