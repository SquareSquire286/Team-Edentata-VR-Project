using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomColliderArea : MonoBehaviour
{
    private bool containsPlayer;
    public RoomActivator roomActivator;

    public bool GetPlayerStatus()
    {
        return this.containsPlayer;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            this.containsPlayer = true;
            roomActivator.UpdateRoomVisibility(this.gameObject);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "MainCamera")
            this.containsPlayer = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "MainCamera")
            this.containsPlayer = false;
    }
}
