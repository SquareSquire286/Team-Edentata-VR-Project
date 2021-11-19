using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : AbstractGrabbable
{
    public GameObject leftHand, rightHand;
    private Rigidbody rigidbody;
    private Vector3 previousPosition;
    private Quaternion previousRotation;
    private AbstractButton button;

    public override void Start()
    {
        button = transform.GetChild(0).gameObject.GetComponent<AbstractButton>();
        isGrabbed = false;
        rigidbody = GetComponent<Rigidbody>();
    }

    public override void WhileGrabbed()
    {
        transform.parent = handGrabbingMe.transform;
        rigidbody.isKinematic = true;

        previousPosition = transform.position;
        previousRotation = transform.rotation;

        if((OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && handGrabbingMe == rightHand) || (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && handGrabbingMe == leftHand))
        {
            button.OnPress();
        }
        else if((OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) && handGrabbingMe == rightHand) || (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger) && handGrabbingMe == leftHand))
        {
            button.OnRelease();
        }
    }

    public override void WhenReleased()
    {
        transform.parent = null;
        rigidbody.isKinematic = false;

        Vector3 velocity = (transform.position - previousPosition) / Time.deltaTime;
        Vector3 angularVelocity = (transform.rotation.eulerAngles - previousRotation.eulerAngles) / Time.deltaTime;
        Debug.Log(velocity);

        rigidbody.drag = 0;
        rigidbody.velocity = velocity;
        rigidbody.angularVelocity = angularVelocity;
    }
}
