using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// *************************************************************************************
// Purpose: What occurs when user presses a button. We dont want the button to access 
//          the object its manipulating. There will be many instances of different types 
//          of buttons. 
//
// Class Variables: none
// *************************************************************************************
public abstract class AbstractButtonEvent : MonoBehaviour
{


    // *********************************************************
    // Functionality: Called once at the beginning of the event
    //
    // Parameters: none
    // Return: none
    // *********************************************************
    public virtual void Start()
    {
        
    }


    // ***********************************************
    // Functionality: Update is called once per frame
    //
    // Parameters: none
    // Return: none
    // ***********************************************
    public virtual void Update()
    {
        
    }


    // **********************************************
    // Functionality: Defined in concrete subclasses
    //
    // Parameters: none
    // Return: none
    // **********************************************
    public virtual void ExecuteEvent()
    {
    
    }

    public virtual void StopEvent()
    {

    }
}
