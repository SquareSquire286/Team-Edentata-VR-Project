using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          hasActivated ->
//          pressedPosition ->
//          room0Controller ->         
//
// ***********************************************************************
public class UpdateRoomConditionsOnPress : MonoBehaviour
{
    private bool hasActivated;
    public Vector3 pressedPosition;
    public RoomController room0Controller;

    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        hasActivated = false;
    }


    // ************************************************************
    // Functionality: Update is called once per frame
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Update()
    {
        if (!hasActivated)
        {
            if (transform.position == pressedPosition)
            {
                room0Controller.UpdateRoomConditions(this.gameObject);
                hasActivated = true;
            }
        }
    }
}
