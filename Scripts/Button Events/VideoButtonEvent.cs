using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// *************************************************************************************
// Purpose: An event type that toggles the play status of a video on button press.
//
// Class Variables: 
//          videoPlayer -> The video player containing the clip that will be played.
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
    // Functionality: Called on the first frame that the corresponding button is
    //                pressed if the last function to be called on button press
    //                was StopEvent. Pauses the video if it is currently playing,
    //                or plays it if it is currently paused.
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void ExecuteEvent()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else 
        {
            videoPlayer.Play();
        }
    }



    // ****************************************************************************
    // Functionality: Called on the first frame that the corresponding button is
    //                pressed if the last function to be called on button press
    //                was ExecuteEvent. Pauses the video.
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void StopEvent()
    {
        videoPlayer.Pause();
    }
}
