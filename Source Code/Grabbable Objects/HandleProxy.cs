using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    HandleProxy is a subclass of AbstractGrabbable that is exclusive to door handles. The reason for this specificity is that the doors possess unique Rigidbody and Joint properties that require
    compensation on the backend in order to prevent unintended physics glitches (e.g. the player being flung backwards by the door if they open the door directly into their head collider).
*/

public class HandleProxy : AbstractGrabbable
{
    public GameObject door, visibleHandle, centerEyeAnchor;
    private Rigidbody doorRigidbody;
    private Collider handleCollider, headCollider;

    public override void Start()
    {
        isGrabbed = false;

        doorRigidbody = door.GetComponent<Rigidbody>();
        handleCollider = visibleHandle.GetComponent<Collider>();
        headCollider = centerEyeAnchor.GetComponent<Collider>(); 
    }

    public override void WhileGrabbed()
    {
        // set the handles position and rotation to the hands position and rotation
        transform.position = handGrabbingMe.transform.position; 
        transform.rotation = handGrabbingMe.transform.rotation;

        doorRigidbody.constraints = RigidbodyConstraints.None;

        // set those to triggers so that theres no collisions after. User wont get flung backwards 
        handleCollider.isTrigger = true;
        headCollider.isTrigger = true;
    }
    
    public override void WhenReleased()
    {
        // set the handles position and rotation to the hands position and rotation
        transform.position = visibleHandle.transform.position;
        transform.rotation = visibleHandle.transform.rotation;

        // apply constraints to door so that it doesnt swing back and forth. 
        doorRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        // set those to triggers so that theres no collisions after. User wont get flung backwards 
        handleCollider.isTrigger = false;
        headCollider.isTrigger = false;
    }

}
