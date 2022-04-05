using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          None     
//
// ***********************************************************************
public class DefaultState : MonoBehaviour
{
    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        Invoke("PressButton", 1f);  
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public void PressButton()
    {
        if (this.gameObject.GetComponent<SpiderIntensityController>() != null)
        {
            this.gameObject.GetComponent<SpiderIntensityController>().OnPress();
        }
        else 
        {
            this.gameObject.GetComponent<SpiderDiversityController>().OnPress();
        }
    }
}
