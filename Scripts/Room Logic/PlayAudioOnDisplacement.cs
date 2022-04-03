using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnDisplacement : MonoBehaviour
{
    private bool hasActivated;
    private Vector3 initialPosition;
    public ManyToOneAudioSource audioSource;
    public GameObject room0Screen;

    // Start is called before the first frame update
    void Start()
    {
        room0Screen.SetActive(false);
        hasActivated = false;
        initialPosition = transform.position;
    }

    // Update is called once per frame
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
