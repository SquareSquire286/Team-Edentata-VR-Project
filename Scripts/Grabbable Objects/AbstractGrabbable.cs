using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ***********************************************************************
// Purpose: The interface for all objects 
//          that can be grabbed and held by the user.
// 
// Class Variables: 
//          isGrabbed -> dictates the objects per frame behaviour                            
//          handGrabbingMe -> the HandAnchor game object that is 
//                            currently holding the object
//          initialMaterial ->
//          rigidbody ->
//          previousPosition ->
//          previousRotation ->
//
// ***********************************************************************
public abstract class AbstractGrabbable : MonoBehaviour
{
    public bool isGrabbed; 
    public GameObject handGrabbingMe;
    public Material initialMaterial;
    public Rigidbody rigidbody;
    public Vector3 previousPosition;
    public Quaternion previousRotation;

    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void Start()
    {
        
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
    // Functionality: If the object's grab status changes from True to False, 
    //                execute the object's while-not-grabbed behaviour
    // 
    // Parameters: newStatus, hand
    // return: none
    // ****************************************************************************
    public virtual void SetGrabStatus(bool newStatus, GameObject hand)
    {
        isGrabbed = newStatus;
        handGrabbingMe = hand;

        if (!newStatus)
        {
            WhenReleased();
        }
    }


    // ****************************************************************************
    // Functionality: Called by Grabber whenever a candidate object is 
    //                found for a HandAnchor to hold - the last condition is that
    //                the object must not already be held by the other Hand Anchor
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

    // ****************************************************************************
    // Functionality: 
    // 
    // Parameters: highlightMaterial
    // return: none
    // ****************************************************************************
    public virtual void ApplyHighlight(Material highlightMaterial)
    {
        if (GetComponent<Renderer>() == null)
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = highlightMaterial;
            }
            else 
            {
                transform.parent.gameObject.GetComponent<Renderer>().material = highlightMaterial;
            }
        }
        else 
        {
            GetComponent<Renderer>().material = highlightMaterial;
        }
    }

    // ****************************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ****************************************************************************
    public virtual void RemoveHighlight()
    {
        if (GetComponent<Renderer>() == null)
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = initialMaterial;
            }
            else 
            {
                transform.parent.gameObject.GetComponent<Renderer>().material = initialMaterial;
            }
        }
        else 
        {
            GetComponent<Renderer>().material = initialMaterial;
        }
    }
}
