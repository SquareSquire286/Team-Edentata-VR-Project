using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// *************************************************************************************
// Purpose: This event is called when the play button on the diaphragmatic breathing screen in room 0 is pressed.
//          Since the audio and video sources are seperate objects with different logic, an additional subclass of abstract button event is required.
//
// Class Variables: 
//          transitionButton -> the button the user presses to unlock room 1. Visibility is controlled by the execution of this event
//          buttonActivationDelayTime -> the amount of time that passes between this event being invoked and the transition button becoming visible. 
//                                       Appears hardcoded in the script, but is public and can actually be changed in the inspector window 
//          videoPlayer -> Instance of class from UnityEngine.Video that plays the tutorial clip on button press.
//          audioSource -> the audio source game object
//          audioHasPlayed -> "Exception Handler" for subsequent button presses; Ensures the audio only plays once
//                
//          
// *************************************************************************************
public class AudioandVideoButtonEvent : AbstractButtonEvent
{
    public GameObject transitionButton;
	public float buttonActivationDelayTime = 17f;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private bool audioHasPlayed;


    // ********************************************************************
    // Functionality: Start is called before the first frame update
    //
    // Parameters: none
    // Return: none
    // ********************************************************************
    public override void Start()
    {
        transitionButton.SetActive(false);
        audioHasPlayed = false;
        audioSource = GetComponent<AudioSource>();
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

        else
        {
            videoPlayer.Play();

            if (!audioHasPlayed)
            {
                audioSource.Play();
                audioHasPlayed = true;
                Invoke("ActivateTransitionButton", buttonActivationDelayTime);
            }
        }
    }


    // ****************************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    private void ActivateTransitionButton()
    {
        transitionButton.SetActive(true);
    }
}
