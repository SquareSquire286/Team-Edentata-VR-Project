using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          containsPlayer ->
//          roomActivator ->
//
// ***********************************************************************
public class RoomColliderArea : MonoBehaviour
{
    private bool containsPlayer;
    public RoomActivator roomActivator;


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public bool GetPlayerStatus()
    {
        return this.containsPlayer;
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            this.containsPlayer = true;
            roomActivator.UpdateRoomVisibility(this.gameObject);
        }
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "MainCamera")
            this.containsPlayer = true;
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "MainCamera")
            this.containsPlayer = false;
    }
}
