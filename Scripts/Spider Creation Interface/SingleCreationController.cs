using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          model    
//
// ***********************************************************************
public class SingleCreationController : AbstractButton
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

        if (model.GetRemainingSpiders() != 0)
        {
            model.CreateSpider();
        }
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
