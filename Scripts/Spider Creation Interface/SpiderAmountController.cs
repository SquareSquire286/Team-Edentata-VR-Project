using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          model ->
//          amountModifier ->
//
// ***********************************************************************
public class SpiderAmountController : AbstractButton
{
    public SpiderCreatorModel model;
    public int amountModifier;


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void OnPress()
    {
        transform.position = pressedPosition;
        Debug.Log(gameObject.name + " pressed");
        model.ChangeMaxAmount(amountModifier);
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void OnRelease()
    {
        transform.position = releasedPosition;
    }
}
