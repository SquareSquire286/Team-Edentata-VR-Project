using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************************************************************************
// Purpose: Grabbable is a subclass of AbstractGrabbable encompassing any 
//          object that can be picked up, held, dropped, and thrown, but 
//          lacks any special characteristics or operations. Examples of 
//          objects that would be given a Grabbable script include pieces 
//          of paper, inanimate spider toys, and other trinkets in the rooms' 
//          desks or dresser drawers.
// *************************************************************************
public class Grabbable : AbstractGrabbable
{
    protected Rigidbody rigidbody;
    protected Vector3 previousPosition;
    protected Quaternion previousRotation;

    
    // ******************************************************************
    // Functionality: Start is called before the first frame update.
    //                Sets the isGrabbed variable to false by default and
    //                instantiates the rigidibody component.
    //                                                              
    // Parameters: none                                             
    // Return: none                                                 
    // ******************************************************************
    public override void Start()
    {
        isGrabbed = false;
        rigidbody = GetComponent<Rigidbody>();
    }


    // ********************************************
    // Functionality: Object is picked up by user, 
    //                and object is rotated to fit
    //                user hand.
    //
    // Parameters: none
    // Return: none
    // ********************************************
    public override void WhileGrabbed()
    {
        transform.parent = handGrabbingMe.transform;
        rigidbody.isKinematic = true;

        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }


    // ******************************************************************************
    // Functionality: Calculates the angular velocity and velocity of the rigid body,
    //                and sets the rigid body velocity, angular velocity to those values upon release. 
    //                Also sets drag to 0 for indoor purposes. 
    // 
    // Parameters: none
    // Return: none
    // ******************************************************************************
    public override void WhenReleased()
    {
        transform.parent = null; 
        rigidbody.isKinematic = false; 

        Vector3 velocity = (transform.position - previousPosition) / Time.deltaTime;
        Vector3 angularVelocity = (transform.rotation.eulerAngles - previousRotation.eulerAngles) / Time.deltaTime;

        rigidbody.drag = 0; 
        rigidbody.velocity = velocity;
        rigidbody.angularVelocity = angularVelocity;
    }
}
