using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildButton : AbstractButton
{
    private bool stoppedLastTime;

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

        if (stoppedLastTime)
            affectedObject.ExecuteEvent();

        else affectedObject.StopEvent();

        stoppedLastTime = !stoppedLastTime;
    }

    public override void OnRelease()
    {
        transform.localScale = releasedPosition;
    }
}
