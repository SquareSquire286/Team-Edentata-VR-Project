using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: Instantiates audio component and plays 
//          selected clip on audio sourceobject
//
// Class Variables: 
//                   audioSource -> the audio source game object
//
//***************************************************************
public class AudioButtonEvent : AbstractButtonEvent
{
    private AudioSource audioSource;
    public bool hasToggleableAudio;
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
    // Functionality: Gets called by button. Plays the selected audio clip.
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

    // Handles the cases where the audio source can play one of many different clips (i.e. the spider information speakers in Room 3)
    private void SwitchClip_ThenPlay()
    {
        if (audioSource.isPlaying) // Prevent NullReferenceExceptions by stopping playback before replacing the AudioClip
            audioSource.Stop();

        audioSource.clip = soundBites[Random.Range(0, soundBites.Length)];
        audioSource.Play(); // Replace the clip to be played by the audio source with a new one in the array, 
    }
}
