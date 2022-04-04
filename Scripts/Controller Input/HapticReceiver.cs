using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: A class responsible for applying haptic feedback to the
//          Oculus controller(s) upon detecting a collision with a
//          HapticGenerator object.
//          Must be applied to the same object as Grabber, as the
//          mechanism of colliding with objects is the same in both
//          scripts, but we chose to separate the functionalities.
//
// Class Variables:
//          controller -> instance of Controller script from which
//                        the correct hand is ascertained
//***************************************************************
public class HapticReceiver : MonoBehaviour
{
    public Controller controller;

    // ****************************************************************************
    // Functionality: checks if the collision was with a HapticGenerator, and if so, applies a vibration function
    // to the correct controller, as dictated by the enumerated hand value                
    //                
    // Parameters: col
    // Return: none
    // *****************************************************************************
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<HapticGenerator>() != null) // indicates collision with a spider
        {
            HapticGenerator generator = col.gameObject.GetComponent<HapticGenerator>();

            if (controller.GetHand() == Hand.Left)
            {
                OVRInput.SetControllerVibration(generator.GetFrequency(), generator.GetAmplitude(), OVRInput.Controller.LTouch);
            }
            else
            {
                OVRInput.SetControllerVibration(generator.GetFrequency(), generator.GetAmplitude(), OVRInput.Controller.RTouch);
            }
        }
    }


    // ****************************************************************************
    // Functionality: 
    //
    // Parameters: col
    // Return: none
    // *****************************************************************************
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<HapticGenerator>() != null) // indicates collision with a spider
        {
            if (controller.GetHand() == Hand.Left)
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            }
            else
            { 
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }
        }
    }
}
