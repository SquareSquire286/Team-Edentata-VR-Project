using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ******************************************************************
// Purpose: Concrete subclass of AbstractButton that is applied to the
//          buttons that unlock doors to the next room(s).
//
// Class Variables: 
//          roomController -> instance of RoomController that
//                            facilitates door-unlocking logic
//          green -> a material which acts as an indicator that the
//                   door has been unlocked
//          renderer -> the Renderer component of the button object
//
//          All class variables from AbstractButton are inherited.
//          The AbstractButtonEvent field must be initialized to an
//          AudioButtonEvent on an audio source that plays a room
//          transition audio clip.
// ******************************************************************
public class TransitionButton : AbstractButton
{
    public RoomController roomController;
    public Material green;
    private Renderer renderer;


    // *************************************************************
    // Functionality: Called on the first frame in which the button
    //                is pressed.
    //                Initializes the renderer field, translates the
    //                visible button object to its pressed position,
    //                executes the corresponding button event, and
    //                replaces the button's default red colour with
    //                a green colour if all room conditions have been
    //                fulfilled.
    //                                                              
    // Parameters: none                                             
    // Return: none                                                 
    // *************************************************************
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
