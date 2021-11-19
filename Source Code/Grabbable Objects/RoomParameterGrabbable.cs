using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomParameterGrabbable : Grabbable
{
    public RoomController roomController;

    public override void SetGrabStatus(bool newStatus, GameObject hand)
    {
        isGrabbed = newStatus;
        handGrabbingMe = hand;

        if (!newStatus)
            WhenReleased();

        else
        {
            roomController.UpdateRoomConditions(this.gameObject);
            roomController.CheckRoomConditions();
        }
    }
}
