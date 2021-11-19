using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//********************************************************************************
// Purpose: HandleProxy is a subclass of AbstractGrabbable that is 
//          exclusive to door handles. The reason for this specificity 
//          is that the doors possess unique Rigidbody and Joint properties 
//          that require compensation on the backend in order to prevent 
//          unintended physics glitches (e.g. the player being flung backwards 
//          by the door if they open the door directly into their head collider).
//********************************************************************************
public class HandleProxy : AbstractGrabbable
{
    public Rigidbody doorRigidbody;
    public Collider handleCollider, headCollider;


    // ****************************************************************************
    // Functionality: Sets the handle position and rotation to the hands position
    //                and rotation. Set them to triggers so that there is no 
    //                chance of collisions after (User wont get thrown backwards)
    // 
    //
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void WhileGrabbed()
    {
        transform.position = handGrabbingMe.transform.position; 
        transform.rotation = handGrabbingMe.transform.rotation;

        doorRigidbody.constraints = RigidbodyConstraints.None;

        
        handleCollider.isTrigger = true;
        headCollider.isTrigger = true;
    }
    

    // ****************************************************************************
    // Functionality: Sets the hands position and rotation to the handles position
    //                and rotation. apply some constraints to the door so it doesnt
    //                swing abruptly (freeze it). Finally set the handle and head 
    //                collider to false so there is no collisions after (User wont 
    //                get thrown backwards)
    // 
    //
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void WhenReleased()
    {
        transform.position = handleCollider.gameObject.transform.position;
        transform.rotation = handleCollider.gameObject.transform.rotation;

        doorRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        handleCollider.isTrigger = false;
        headCollider.isTrigger = false;
    }

}
