using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *****************************************************************************************
// Purpose: Interface for any button that can be pressed / held with the controller Triggers
// *****************************************************************************************
public abstract class AbstractButton : MonoBehaviour
{
    public bool isPressed;
    public Vector3 releasedPosition, pressedPosition;
    public AbstractButtonEvent affectedObject;
    
    
    // *************************************************************
    // Functionality: Start is called before the first frame update 
    //                                                              
    // Parameters: none                                             
    // Return: none                                                 
    // *************************************************************
    public virtual void Start()
    {
        isPressed = false; 
        transform.position = releasedPosition;
    }


    // **********************************************
    // Functionality: Update is called once per frame   
    //                                                          
    // Parameters: none
    // return: none                            
    // **********************************************
    public virtual void Update()
    {
      
    }


    // **************************************************
    // Functionality: presses the button if true,                 
    //                otherwise releases the button.              
    //                                                            
    // Parameters: newStatus -> true if button is pressed         
    // return: current state of button                            
    // **************************************************
    public virtual void SetPressStatus(bool newStatus)
    {
        isPressed = newStatus;

        if (isPressed)
        {
            OnPress();
        }

        else 
        {
            OnRelease();
        }
    }


    //***********************************
    // Functionality: Button is pressed
    //
    // Parameters: none
    // return: none         
    //***********************************
    public virtual void OnPress()
    {
        transform.position = pressedPosition;
        affectedObject.ExecuteEvent();
    }


    // ***********************************
    // Functionality: Button is released
    //
    // Parameters: none
    // return: none
    // ***********************************      
    public virtual void OnRelease()
    {
        transform.position = releasedPosition;
        affectedObject.StopEvent();
    }
    
}
