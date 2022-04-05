using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          diversity ->
//          model ->
//          otherDiversityButtons ->
//          pressedMaterial ->
//          revertedMaterial ->
//   
//
// ***********************************************************************
public class SpiderDiversityController : AbstractButton
{
    public SpiderDiversity diversity;
    public SpiderCreatorModel model;
    public List<SpiderDiversityController> otherDiversityButtons;
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

        foreach (SpiderDiversityController button in otherDiversityButtons)
        {
            button.Reset();
        }

        model.SetDiversity(diversity);
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
        if (model.GetDiversity() != diversity)
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
        model.SetDiversity(SpiderDiversity.Void);
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
