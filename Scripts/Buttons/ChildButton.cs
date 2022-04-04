using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************************************************************************************
// Purpose: A concrete subclass of AbstractButton that applies to the button on the remote
//          object in Room 2.
//
// Class Variables: 
//          stoppedLastTime -> a Boolean condition that stores the previous state of the video
//          roomController -> instance of RoomController script that facilitates room
//                            parameter logic
//          All class variables from AbstractButton are inherited.
//          The AbstractButtonEvent variable must be initialized to a VideoButtonEvent in
//          the Unity Inspector window (i.e. the spider video player in Room 2).
//                
//          
// *************************************************************************************
public class ChildButton : AbstractButton
{
    private bool stoppedLastTime;
    public RoomController roomController;

    // *************************************************************
    // Functionality: Start is called before the first frame update.
    //                Initializes the two boolean conditions and the
    //                button's starting position.
    //                                                              
    // Parameters: none                                             
    // Return: none                                                 
    // *************************************************************
    public override void Start()
    {
        stoppedLastTime = true;
        isPressed = false;
        transform.localScale = releasedPosition;
    }


    
    // ****************************************************************************
    // Functionality: Called when the button is pressed. Updates the button's
    //                position, communicates to the RoomController field that the
    //                condition has been fulfilled, and toggles the status of the
    //                AbstractButtonEvent based on the previous state.
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public override void OnPress()
    {
        transform.localScale = pressedPosition;
        roomController.UpdateRoomConditions(this.gameObject);

        if (stoppedLastTime)
        {
            affectedObject.ExecuteEvent();
        }
        else 
        {
            affectedObject.StopEvent();
        }

        stoppedLastTime = !stoppedLastTime;
    }


    // ****************************************************************************
    // Functionality: Button is released to its default position.
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public override void OnRelease()
    {
        transform.localScale = releasedPosition;
    }
}
