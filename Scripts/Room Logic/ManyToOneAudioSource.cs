using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyToOneAudioSource : MonoBehaviour
{
    private bool hasBeenActivated;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasBeenActivated = false;    
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }

    public void Activate()
    {
        if (!hasBeenActivated)
        {
            audioSource.Play();
            hasBeenActivated = true;

            // logic for activating diaphragmatic breathing screen
        }
    }
}
