using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// *************************************************************************************
// Purpose: 
//
// Class Variables: 
//          videoPlayer ->
//                
//          
// *************************************************************************************
public class VideoButtonEvent : AbstractButtonEvent
{
    private VideoPlayer videoPlayer;


    // ****************************************************************************
    // Functionality: Start is called before the first frame update. Ensures 
    //                the video component gets attached to the video source object.
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }


    // ****************************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void ExecuteEvent()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();

        else videoPlayer.Play();
    }



    // ****************************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void StopEvent()
    {
        videoPlayer.Pause();
    }
}
