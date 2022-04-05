using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          madeContact ->
//          audioSource ->
//
// ***********************************************************************
public class PlayAudioOnHeadCollision : MonoBehaviour
{
    private bool madeContact;
    public AudioSource audioSource;

    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        madeContact = false;    
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
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    void OnTriggerEnter(Collider col)
    {
        if (Time.time > 15.0f && col.gameObject.layer == 9) // 9 is the Head layer
        {
            if (!madeContact)
            {
                audioSource.Play();
                madeContact = true;
            }
        }
    }
}
