using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: 
//
// Class Variables: 
//          leftHand ->
//          rightHand ->
//          button ->
//***************************************************************
public class Remote : RoomParameterGrabbable
{
    public GameObject leftHand, rightHand;
    public AbstractButton button;

    // ****************************************************************************
    // Functionality: 
    // 
    //
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void Start()
    {
        isGrabbed = false;
        rigidbody = GetComponent<Rigidbody>();
    }


    // ****************************************************************************
    // Functionality: 
    // 
    //
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void WhileGrabbed()
    {
        transform.parent = handGrabbingMe.transform;
        rigidbody.isKinematic = true;

        previousPosition = transform.position;
        previousRotation = transform.rotation;

        this.RemoveHighlight();

        if ((OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && handGrabbingMe == rightHand) || (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && handGrabbingMe == leftHand))
        {
            float timeLastPressed;

            if (handGrabbingMe == rightHand)
            {
                timeLastPressed = rightHand.GetComponent<Grabber>().GetTimeLastPressed();
            }
            else 
            {
                timeLastPressed = leftHand.GetComponent<Grabber>().GetTimeLastPressed();
            }

            if (Time.time - timeLastPressed > 0.6f)
            {
                button.OnPress();
                rightHand.GetComponent<Grabber>().SetTimeLastPressed(Time.time);
                leftHand.GetComponent<Grabber>().SetTimeLastPressed(Time.time);
            }
        }
        else if ((OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) && handGrabbingMe == rightHand) || (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger) && handGrabbingMe == leftHand))
        {
            button.OnRelease();
        }
    }

    // ****************************************************************************
    // Functionality: 
    // 
    //
    // Parameters: none
    // Return: none
    // *****************************************************************************
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
