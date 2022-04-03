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

        this.RemoveHighlight();

        if (!newStatus)
            WhenReleased();

        else
        {
            roomController.UpdateRoomConditions(this.gameObject);
        }
    }

    public override void ApplyHighlight(Material highlightMaterial)
    {
        if (GetComponent<Renderer>() == null)
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = highlightMaterial;

        else GetComponent<Renderer>().material = highlightMaterial;
    }

    public override void RemoveHighlight()
    {
        if (GetComponent<Renderer>() == null)
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = initialMaterial;

        else GetComponent<Renderer>().material = initialMaterial;
    }
}
