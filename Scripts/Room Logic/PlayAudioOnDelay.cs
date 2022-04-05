using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          audioSource ->
//          delayTime ->
// ***********************************************************************
public class PlayAudioOnDelay : MonoBehaviour
{
    private AudioSource audioSource;
    public float delayTime;

    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayAudio", delayTime);
    }


    // ************************************************************
    // Functionality: Update is called once per frame
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Update()
    {
        
    }

    // ************************************************************
    // Functionality: Plays audio
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void PlayAudio()
    {
        audioSource.Play();
    }
}
