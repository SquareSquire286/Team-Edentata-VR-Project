using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          hasActivated ->
//          initialPosition ->
//          audioSource ->
//          room0Screen ->
// ***********************************************************************
public class PlayAudioOnDisplacement : MonoBehaviour
{
    private bool hasActivated;
    private Vector3 initialPosition;
    public ManyToOneAudioSource audioSource;
    public GameObject room0Screen;

    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        room0Screen.SetActive(false);
        hasActivated = false;
        initialPosition = transform.position;
    }



    // ************************************************************
    // Functionality: Update is called once per frame
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Update()
    {
        if (!hasActivated)
        {
            if (transform.position != initialPosition)
            {
                room0Screen.SetActive(true);
                hasActivated = true;
                audioSource.Activate();
            }
        }
    }
}
