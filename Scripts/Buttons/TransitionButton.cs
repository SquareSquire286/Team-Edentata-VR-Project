using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ******************************************************************
// Purpose: uses everything in AbstractButton. Used as a base
//          class for buttons.
//
// Class Variables: none
// ******************************************************************
public class TransitionButton : AbstractButton
{
    public RoomController roomController;
    public Material green;
    private Renderer renderer;

    public override void OnPress()
    {
        renderer = GetComponent<Renderer>();

        transform.position = pressedPosition;
        affectedObject.ExecuteEvent();

        if (roomController.CheckRoomConditions())
        {
            renderer.material = green;
            initialMaterial = green;
        }
    }
}
