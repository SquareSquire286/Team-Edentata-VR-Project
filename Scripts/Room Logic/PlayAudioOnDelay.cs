using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnDelay : MonoBehaviour
{
    private AudioSource audioSource;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayAudio", delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAudio()
    {
        audioSource.Play();
    }
}
