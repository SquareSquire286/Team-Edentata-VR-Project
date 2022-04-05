using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          model ->    
//
// ***********************************************************************
public class MassCreationController : AbstractButton
{
    public SpiderCreatorModel model;


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void OnPress()
    {
        transform.position = pressedPosition;
        int spiderLimit = model.GetRemainingSpiders();

        model.CreateAllSpiders(spiderLimit);
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
