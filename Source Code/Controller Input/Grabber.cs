using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: This class implements the hand functions for the Oculus 
//          Quest. Its main functions allow the user to pick up 
//          objects and let them go. 
//***************************************************************
public class Grabber : MonoBehaviour
{
    private List<GameObject> currentCollisions, buttons;
    public string handString; 
    private string leftHandString, rightHandString;
    private GameObject grabbedObject, pressedButton;
    private bool grabbed;
    private float timeLastPressed;

    // ****************************************************************************
    // Functionality: Start is called before the first frame update. Instantiates
    //                both hand possibilities, as well as any objects that can be 
    //                grabbed or pushed/pulled.
    // 
    //
    // Parameters: none
    // Return: none
    // *****************************************************************************
    void Start()
    {
        grabbed = false; 
        grabbedObject = null;
        currentCollisions = new List<GameObject>();
        buttons = new List<GameObject>();
        leftHandString = "Left";
        rightHandString = "Right";
        timeLastPressed = -200f; // sentinel value
    }


    // ****************************************************************************
    // Functionality: First checks what hand is grabbing the object, then calls the
    //                set grab status for that object. It then checks if the object 
    //                is being released and to detach itself from the user.
    // 
    //
    // Parameters: none
    // Return: none
    // *****************************************************************************
    void Update()
    { 
        
        if((OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) && handString == rightHandString) || (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger) && handString == leftHandString))
        {
            grabbed = false; 
            
            if(grabbedObject != null)
            {
                grabbedObject.GetComponent<AbstractGrabbable>().SetGrabStatus(false, null);
            }

            grabbedObject = null; 
        }
        
        if((OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) && handString == rightHandString) || (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger) && handString == leftHandString))
        {
            if(pressedButton != null)
            {
                pressedButton.GetComponent<AbstractButton>().OnRelease();
            }

            pressedButton = null;
        }
    }


    // ****************************************************************************
    // Functionality: Called on the very first frame that a collider contacts 
    //                another collider. Checks the gameObject (hand, button, etc) 
    //                for a specific script attached, and if it does it will add its
    //                collider to a list of colliders.
    //                
    //                
    // Parameters: none
    // Return: none
    // *****************************************************************************
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<AbstractGrabbable>() != null)
        {
            currentCollisions.Add(col.gameObject); 
        }
        else if(col.gameObject.GetComponent<AbstractButton>() != null)
        {
            buttons.Add(col.gameObject);
        }   
    }


    // ****************************************************************************
    // Functionality: When the collider stays in contact with the trigger collider. 
    //                Is much better than update(). Worst case O(n), best case O(1).
    //                First checks if user is holding the trigger on a controller, 
    //                then looks for an object already being grabbed. If no object
    //                is being held, then it will make sure that the hand not 
    //                grabbing anything cant steal the object trying to be grabbed. 
    //              
    //                The last condition checks the index of the trigger, which only 
    //                cares about the first frame that it is pressed. 
    //                
    //                
    // Parameters: none
    // Return: none
    // *****************************************************************************
    void OnTriggerStay(Collider col)
    {
        if((OVRInput.Get(OVRInput.RawButton.RHandTrigger) && handString == rightHandString) || (OVRInput.Get(OVRInput.RawButton.LHandTrigger) && handString == leftHandString))
        {
            if(!grabbed && grabbedObject == null && currentCollisions.Count > 0)
            {
                if(!currentCollisions.ElementAt(currentCollisions.Count - 1).GetComponent<AbstractGrabbable>().GetGrabStatus())
                {
                    grabbedObject = currentCollisions.ElementAt(currentCollisions.Count - 1); 
                    grabbed = true;
                    grabbedObject.GetComponent<AbstractGrabbable>().SetGrabStatus(true, this.gameObject);
                }
            }
        }

        if ((OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && handString == rightHandString) || (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && handString == leftHandString))
        {
            if (buttons.Count > 0 && (Time.time - timeLastPressed >= 0.6f))
            {
                pressedButton = buttons.ElementAt(buttons.Count - 1);
                pressedButton.GetComponent<AbstractButton>().OnPress();
                timeLastPressed = Time.time;
            }
        }
    }


    // ****************************************************************************
    // Functionality: Checks if previously triggered collider is exited. 
    //                Is called on the frame Unity registers that there isn't anything 
    //                being collided.
    //                
    //                
    // Parameters: none
    // Return: none
    // *****************************************************************************
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.GetComponent<AbstractGrabbable>() != null)
        {
            currentCollisions.Remove(col.gameObject); 
        }

        else if(col.gameObject.GetComponent<AbstractButton>() != null)
        {
            buttons.Remove(col.gameObject);
        }
    }
}