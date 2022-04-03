using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************************************************************************************
// Purpose: Interface for any button that can be pressed / held with the controller Triggers
//
// Class Variables: 
//          initialMaterial ->
//          isPressed ->
//          releasedPosition ->
//          pressedPosition ->
//          affectedObject ->
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
    // Return: current state of button
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
    // Functionality: Button is pressed
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
    // Functionality: Button is released
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public virtual void ApplyHighlight(Material highlightMaterial)
    {
        if (GetComponent<Renderer>() == null)
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = highlightMaterial;

        else GetComponent<Renderer>().material = highlightMaterial;
    }


    // ****************************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // Return: none
    // ****************************************************************************
    public virtual void RemoveHighlight()
    {
        if (GetComponent<Renderer>() == null)
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = initialMaterial;

        else GetComponent<Renderer>().material = initialMaterial;
    }
}
