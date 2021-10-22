using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private List<GameObject> currentCollisions, buttons;
    public string handString; // needs to be either "Left" or "Right"
    private string leftHandString, rightHandString;
    private GameObject grabbedObject, pressedButton;
    private bool grabbed;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false; 
        grabbedObject = null;
        currentCollisions = new List<GameObject>();
        buttons = new List<GameObject>();
        leftHandString = "Left";
        rightHandString = "Right";
    }

    // Update is called once per frame
    void Update()
    { 
        // if we find that the button has been let go on that frame, we set grabbed to false.
        if ((OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) && handString == rightHandString) || (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger) && handString == leftHandString))
        {
            grabbed = false; // no object is being grabbed right now
            
            if (grabbedObject != null)
                grabbedObject.GetComponent<AbstractGrabbable>().SetGrabStatus(false, null); // calls set grab status. calls the when released function. calculates exit velocity.

            grabbedObject = null; 
        }
        
        if ((OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) && handString == rightHandString) || (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger) && handString == leftHandString))
        {
            if (pressedButton != null)
                pressedButton.GetComponent<AbstractButton>().OnRelease();

            pressedButton = null;
        }
    }

    // default function by Unity. Called on the very first frame that a collider contacts another collider.
    // only reason why grabbing objects works
    void OnTriggerEnter(Collider col)
    {
        // check if gameObject that is being grabbed has a AbstractGrabbable script attached
        if (col.gameObject.GetComponent<AbstractGrabbable>() != null)
        {
            currentCollisions.Add(col.gameObject); 
        }
        // check if the gameObject that is being grabbed has a AbstractButton script attached. Has a different input altogether
        else if (col.gameObject.GetComponent<AbstractButton>() != null)
        {
            buttons.Add(col.gameObject);
        }   
    }

    // another default function by Unity. When the collider stays in contact with the trigger collider. much better than update. Worst case O(n), best case O(1)
    void OnTriggerStay(Collider col)
    {
        // Get() returns true if a button is held down. GetDown() returns true on the first frame a button is pressed. GetUp() returns true on the first frame a button is released.
        if ((OVRInput.Get(OVRInput.RawButton.RHandTrigger) && handString == rightHandString) || (OVRInput.Get(OVRInput.RawButton.LHandTrigger) && handString == leftHandString))
        {
            // check if hand is already grabbing an object. check if there is more than 1 current collision, in the list of collision.
            if (!grabbed && grabbedObject == null && currentCollisions.Count > 0)
            {
                // if the last element in the currentCollision list is not being grabbed. prevents the left hand from stealing whats in the right hand, and vice versa.
                if (!currentCollisions.ElementAt(currentCollisions.Count - 1).GetComponent<AbstractGrabbable>().GetGrabStatus())
                {
                    grabbedObject = currentCollisions.ElementAt(currentCollisions.Count - 1); // the hand will grab the most recent grabbable object that it collided with
                    grabbed = true;
                    grabbedObject.GetComponent<AbstractGrabbable>().SetGrabStatus(true, this.gameObject);
                }
            }
        }

        // check for the index trigger, not the hand trigger. We only care about the first frame that is pressed -> getDown()
        if ((OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && handString == rightHandString) || (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && handString == leftHandString))
        {
            if (buttons.Count > 0)
            {
                pressedButton = buttons.ElementAt(buttons.Count - 1);
                pressedButton.GetComponent<AbstractButton>().OnPress();
            }
        }
    }

    // defualt in unity
    // check and see if previously triggered collider is exited. on the frame unity registers that there isnt anything being collided.
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<AbstractGrabbable>() != null)
        {
            currentCollisions.Remove(col.gameObject); // remove the collision from the list of collisions
        }
        else if (col.gameObject.GetComponent<AbstractButton>() != null)
        {
            buttons.Remove(col.gameObject);
        }
    }
}