using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************************************************************************************
// Purpose: A concrete subclass of AbstractButton that applies to the button in the
//          hallway after Room 4. If the user presses it, the application will terminate.
//
// Class Variables: 
//          All class variables from AbstractButton are inherited.
//                
//          
// *************************************************************************************
public class FinishButton : AbstractButton
{
    // *************************************************************
    // Functionality: Called on the first frame that the button is
    //                pressed. Sets the button to its pressed position,
    //                then checks if the application is being played
    //                in the Unity Editor. If so, Play Mode is stopped,
    //                and if not, the application is assumed to be
    //                running as a standalone, so it is simply quit.
    //                                                              
    // Parameters: none                                             
    // Return: none                                                 
    // *************************************************************
    public override void OnPress()
    {
        transform.position = pressedPosition;

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
