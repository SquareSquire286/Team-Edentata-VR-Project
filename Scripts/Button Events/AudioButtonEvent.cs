using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: Goes on object with audio source component. 
//          Plays audio when user interacts with button that triggers this event
//
// Class Variables: 
//          audioSource -> the audio source game object
//          hasToggleableAudio -> Facilitates random audio selection before playing if necessary
//          soundBites -> array of audio clips. Only populated if hasToggleableAudio is True
//
//***************************************************************
public class AudioButtonEvent : AbstractButtonEvent
{
    private AudioSource audioSource;
    public bool hasToggleableAudio; // Used in Room 3, for education content
    public AudioClip[] soundBites;


    // ****************************************************************************
    // Functionality: Start is called before the first frame update. Ensures 
    //                the audio component gets attached to the audio source object.
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }



    // ********************************************************************
    // Functionality: Gets called on button press. Checks state of hasToggleableAudio 
    //                to see if it needs to select a new clip, then plays it.
    //
    // Parameters: none
    // Return: none
    // ********************************************************************
    public override void ExecuteEvent()
    {
        if (hasToggleableAudio)
            this.SwitchClip_ThenPlay();

        else audioSource.Play();
    }


    // ******************************************************************** 
    // Functionality: Handles the cases where the audio source can play one of 
    //                many different clips (i.e. the spider information speakers in Room 3)
    //
    // Parameters: none
    // Return: none
    // ********************************************************************
    private void SwitchClip_ThenPlay()
    {
        if (audioSource.isPlaying) // Prevent NullReferenceExceptions by stopping playback before replacing the AudioClip
            audioSource.Stop();

        audioSource.clip = soundBites[Random.Range(0, soundBites.Length)];
        audioSource.Play(); // Replace the clip to be played by the audio source with a new one in the array, 
    }
}
