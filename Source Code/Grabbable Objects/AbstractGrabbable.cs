using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ***********************************************************************
// Purpose: The interface for all objects 
//          that can be grabbed and held by the user.
// 
// Class Variables: 
//                   isGrabbed -> dictates the objects per
//                                frame behaviour
//
//                   handGrabbingMe -> the HandAnchor game object that is 
//                                     currently holding the object
// ***********************************************************************
public abstract class AbstractGrabbable : MonoBehaviour
{
    public bool isGrabbed; 
    public GameObject handGrabbingMe; 


    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void Start()
    {
        isGrabbed = false;
    }


    // ****************************************************************************
    // Functionality: Update is called once per frame. If the object's
    //                grab status is true, then execute its while-grabbed behaviour
    //                on a per frame basis
    // 
    // Parameters: none
    // return: none
    // ****************************************************************************
    public virtual void FixedUpdate()
    {
        if (isGrabbed) 
            WhileGrabbed();
    }


    // ****************************************************************************
    // Functionality: If the object's grab status chnages from True to False, 
    //                execute the object's while-not-grabbed behaviour
    // 
    // Parameters: none
    // return: none
    // ****************************************************************************
    public virtual void SetGrabStatus(bool newStatus, GameObject hand)
    {
        isGrabbed = newStatus;
        handGrabbingMe = hand;

        if (!newStatus) 
            WhenReleased();
    }


    // ****************************************************************************
    // Functionality: Called by Grabber whenever a candidate object is 
    //                found for a HandAnchor to hold - the last condition is that
    //                the objectmust not alreadybe held by the other HandAnchor
    // 
    // Parameters: none
    // return: isGrabbed - boolean
    // ****************************************************************************
    public virtual bool GetGrabStatus() 
    {
        return isGrabbed;
    }


    // ****************************************************************************
    // Functionality: Defined in concrete subclasses - called every 
    //                frame that isGrabbed is true
    // 
    // Parameters: none
    // return: none
    // ****************************************************************************
    public virtual void WhileGrabbed()
    {

    }


    // ****************************************************************************
    // Functionality: Defined in concrete subclasses - called on the 
    //                exact frame that isGrabbed becomes false
    // 
    // Parameters: none
    // return: none
    // ****************************************************************************
    public virtual void WhenReleased()
    {
        
    }
}
