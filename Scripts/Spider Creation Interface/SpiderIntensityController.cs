using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          intensity ->
//          model ->
//          otherIntensityButtons ->
//          pressedMaterial ->
//          revertedMaterial ->
//   
//
// ***********************************************************************
public class SpiderIntensityController : AbstractButton
{
    public SpiderIntensity intensity;
    public SpiderCreatorModel model;
    public List<SpiderIntensityController> otherIntensityButtons;
    public Material pressedMaterial;
    private Material revertedMaterial;


    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void Start()
    {
        initialMaterial = GetComponent<Renderer>().material;
        revertedMaterial = initialMaterial;
        isPressed = false;
        transform.position = releasedPosition;
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void OnPress()
    {
        transform.position = pressedPosition;
        revertedMaterial = pressedMaterial;

        foreach (SpiderIntensityController button in otherIntensityButtons)
        {
            button.Reset();
        }

        model.SetIntensity(intensity);
        GetComponent<Renderer>().material = pressedMaterial;
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void OnRelease()
    {
        if (model.GetIntensity() != intensity)
        {
            transform.position = releasedPosition;
        }
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public void Reset()
    {
        transform.position = releasedPosition;
        revertedMaterial = initialMaterial;
        model.SetIntensity(SpiderIntensity.Void);
        GetComponent<Renderer>().material = initialMaterial;
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void RemoveHighlight()
    {
        if (GetComponent<Renderer>() == null)
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = revertedMaterial;
        }
        else 
        {
            GetComponent<Renderer>().material = revertedMaterial;
        }
    }
}
