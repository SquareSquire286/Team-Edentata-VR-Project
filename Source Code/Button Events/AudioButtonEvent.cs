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
        audioSource.Play();
    }
}
