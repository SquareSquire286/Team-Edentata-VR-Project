using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// *************************************************************************************
// Purpose: An event type that toggles the visibility of a text element on button press.
//
// Class Variables: 
//          text -> The text element to be manipulated.
//                
//          
// *************************************************************************************
public class TextButtonEvent : AbstractButtonEvent
{
    private Text text;


    // ****************************************************************************
    // Functionality: Start is called before the first frame update. 
    //                Initializes the text element and deactivates it on startup.
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }


    // ****************************************************************************
    // Functionality: Called on the first frame that the corresponding button is
    //                pressed. Sets the text element's visibility to true.
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void ExecuteEvent()
    {
        text.enabled = true;
    }
}
