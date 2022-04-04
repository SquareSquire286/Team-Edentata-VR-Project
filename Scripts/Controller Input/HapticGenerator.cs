using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: A data class for objects capable of generating
//          haptic feedback (vibration) on the Oculus controllers.
//          The frequency and amplitude variables are not directly
//          accessible to other classes, but they can be initialized
//          by the user in the Unity Inspector window.
//
// Class Variables:
//          frequency -> floating-point value for the frequency of
//                       the vibration applied to the controller(s)
//          amplitude -> floating-point value for the amplitude of
//                       the vibration applied to the controller(s)
//***************************************************************
public class HapticGenerator : MonoBehaviour
{
    [SerializeField] float frequency, amplitude;

    // ****************************************************************************
    // Functionality: returns the frequency of the haptic generator
    //                
    //                
    // Parameters: none
    // Return: frequency
    // *****************************************************************************
    public float GetFrequency() 
    {
        return frequency;
    }

    // ****************************************************************************
    // Functionality: returns the amplitude of the haptic generator
    //                
    //                
    // Parameters: none
    // Return: amplitude
    // *****************************************************************************
    public float GetAmplitude() 
    {
        return amplitude;
    }
}
