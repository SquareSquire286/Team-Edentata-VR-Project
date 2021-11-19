using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChildButton : AbstractButton
{
    private bool stoppedLastTime;
    public RoomController roomController;

    // Start is called before the first frame update
    public override void Start()
    {
        stoppedLastTime = true;
        isPressed = false;
        transform.localScale = releasedPosition;
    }

    public override void OnPress()
    {
        transform.localScale = pressedPosition;

        stoppedLastTime = !stoppedLastTime;
        roomController.UpdateRoomConditions(this.gameObject);
        roomController.CheckRoomConditions();

        if (stoppedLastTime)
            affectedObject.ExecuteEvent();

        else affectedObject.StopEvent();
    }

    public override void OnRelease()
    {
        transform.localScale = releasedPosition;
    }
}
