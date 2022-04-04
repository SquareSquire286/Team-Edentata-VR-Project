using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************************************************************************************
// Purpose: 
//
// Class Variables: 
//          stoppedLastTime ->
//          roomController ->
//                
//          
// *************************************************************************************
public class ChildButton : AbstractButton
{
    private bool stoppedLastTime;
    public RoomController roomController;



    // *************************************************************
    // Functionality: Start is called before the first frame update 
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
    // Functionality: Button is pressed
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public override void OnPress()
    {
        Debug.Log("Stopped last time: " + stoppedLastTime);
        transform.localScale = pressedPosition;
        roomController.UpdateRoomConditions(this.gameObject);

        if (stoppedLastTime)
            affectedObject.ExecuteEvent();

        else affectedObject.StopEvent();

        stoppedLastTime = !stoppedLastTime;
    }


    // ****************************************************************************
    // Functionality: Button is released
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public override void OnRelease()
    {
        transform.localScale = releasedPosition;
    }
}
