using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// *************************************************************************************
// Purpose: 
//
// Class Variables: 
//          text ->
//                
//          
// *************************************************************************************
public class TextButtonEvent : AbstractButtonEvent
{
    private Text text;


    // ****************************************************************************
    // Functionality: Start is called before the first frame update. 
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }


    // ****************************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // Return: none
    // *****************************************************************************
    public override void ExecuteEvent()
    {
        text.enabled = true;
    }
}
