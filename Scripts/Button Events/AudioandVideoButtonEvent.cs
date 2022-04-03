using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioandVideoButtonEvent : AbstractButtonEvent
{
    public GameObject transitionButton;
	public float buttonActivationDelayTime = 17f;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private bool audioHasPlayed;

    // Start is called before the first frame update
    public override void Start()
    {
        transitionButton.SetActive(false);
        audioHasPlayed = false;
        audioSource = GetComponent<AudioSource>();
        videoPlayer = GetComponent<VideoPlayer>();
    }

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

    private void ActivateTransitionButton()
    {
        transitionButton.SetActive(true);
    }
}
