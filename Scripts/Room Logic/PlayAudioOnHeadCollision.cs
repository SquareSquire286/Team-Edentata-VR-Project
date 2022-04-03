using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnHeadCollision : MonoBehaviour
{
    private bool madeContact;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        madeContact = false;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
