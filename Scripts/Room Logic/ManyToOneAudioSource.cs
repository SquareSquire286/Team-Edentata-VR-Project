using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          hasBeenActivated ->
//          audioSource ->
// ***********************************************************************
public class ManyToOneAudioSource : MonoBehaviour
{
    private bool hasBeenActivated;
    private AudioSource audioSource;


    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasBeenActivated = false;    
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
    // Functionality: logic for activating diaphragmatic breathing screen
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public void Activate()
    {
        if (!hasBeenActivated)
        {
            audioSource.Play();
            hasBeenActivated = true;


        }
    }
}
