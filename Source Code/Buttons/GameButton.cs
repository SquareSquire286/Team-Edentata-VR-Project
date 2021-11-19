using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ******************************************************************
// Purpose: uses everything in AbstractButton. Used as a base
//          class for buttons.
//
// Class Variables: none
// ******************************************************************
public class GameButton : AbstractButton
{
    public RoomController roomController;

    public override void OnPress()
    {
        transform.position = pressedPosition;
        affectedObject.ExecuteEvent();
        roomController.UpdateRoomConditions(this.gameObject);
        roomController.CheckRoomConditions();
    }
}
