using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          headString ->
//          roomController ->               
//
// ***********************************************************************
public class UpdateRoomConditionsOnCollision : MonoBehaviour
{
    public string headString;
    public RoomController roomController;


    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        
    }


    // ************************************************************
    // Functionality: Update is called once per frame
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Update()
    {
        
    }

    // ************************************************************
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == headString)
        {
            roomController.UpdateRoomConditions(this.gameObject);
        }
    }
}
