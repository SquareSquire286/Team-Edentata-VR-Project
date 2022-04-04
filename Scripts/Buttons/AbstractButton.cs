using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************************************************************************************
// Purpose: Interface for any button that can be pressed / held with the controller Triggers
//
// Class Variables: 
//          initialMaterial -> the button's default material
//          isPressed -> a Boolean condition that indicates whether the button is currently in the pressed state or not
//          releasedPosition -> a 3D vector that represents the button's position when it is not pressed
//          pressedPosition -> a 3D vector that represents the button's position when it has been pressed
//          affectedObject -> an AbstractButtonEvent that is triggered by the pressing of this button
//                
//          
// *************************************************************************************
public abstract class AbstractButton : MonoBehaviour
{
    public Material initialMaterial;
    protected bool isPressed;
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
        initialMaterial = GetComponent<Renderer>().material;
        isPressed = false; 
        transform.position = releasedPosition;
    }


    // ****************************************************************************
    // Functionality: Update is called once per frame   
    //                                                          
    // Parameters: none
    // return: none                            
    // ****************************************************************************
    public virtual void Update()
    {
      
    }


    // ****************************************************************************
    // Functionality: presses the button if true,                 
    //                otherwise releases the button.  
    // 
    // Parameters: newStatus -> true if button is pressed 
    // Return: none
    // ****************************************************************************
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


    // ****************************************************************************
    // Functionality: The button is translated to its pressed position, and its
    //                corresponding event (if initialized in the Unity Inspector
    //                window) is executed.
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public virtual void OnPress()
    {
        transform.position = pressedPosition;
        affectedObject.ExecuteEvent();
    }


    // ****************************************************************************
    // Functionality: Button is released
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public virtual void OnRelease()
    {
        transform.position = releasedPosition;
    }



    // ****************************************************************************
    // Functionality: Temporary applies the highlight material to the button object
    //                when either of the Oculus controllers is hovering over it.
    //                For some objects, the visible button model is a child object
    //                of an invisible "grab box" that handles collisions, so the
    //                function needs to check if the object handling collisions has
    //                a Renderer component before it attempts to apply the material.
    // 
    // Parameters: highlightMaterial
    // Return: none
    // ****************************************************************************
    public virtual void ApplyHighlight(Material highlightMaterial)
    {
        if (GetComponent<Renderer>() == null)
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = highlightMaterial;
        }
        else 
        {
            GetComponent<Renderer>().material = highlightMaterial;
        }
    }


    // ****************************************************************************
    // Functionality: Removes the highlight material from the button object and 
    //                reapplies the initial material when a collision with the
    //                Oculus controllers is no longer detected.
    //                For some objects, the visible button model is a child object
    //                of an invisible "grab box" that handles collisions, so the
    //                function needs to check if the object handling collisions has
    //                a Renderer component before it attempts to apply the material.
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public virtual void RemoveHighlight()
    {
        if (GetComponent<Renderer>() == null)
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = initialMaterial;
        }
        else 
        {
            GetComponent<Renderer>().material = initialMaterial;
        }
    }
}
