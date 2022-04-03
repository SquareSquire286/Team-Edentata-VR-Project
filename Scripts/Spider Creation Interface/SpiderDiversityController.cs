using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDiversityController : AbstractButton
{
    public SpiderDiversity diversity;
    public SpiderCreatorModel model;
    public List<SpiderDiversityController> otherDiversityButtons;
    public Material pressedMaterial;
    private Material revertedMaterial;

    public override void Start()
    {
        initialMaterial = GetComponent<Renderer>().material;
        revertedMaterial = initialMaterial;
        isPressed = false;
        transform.position = releasedPosition;
    }

    public override void OnPress()
    {
        transform.position = pressedPosition;
        revertedMaterial = pressedMaterial;

        foreach (SpiderDiversityController button in otherDiversityButtons)
            button.Reset();

        model.SetDiversity(diversity);
        GetComponent<Renderer>().material = pressedMaterial;
    }

    public override void OnRelease()
    {
        if (model.GetDiversity() != diversity)
            transform.position = releasedPosition;
    }

    public void Reset()
    {
        transform.position = releasedPosition;
        revertedMaterial = initialMaterial;
        model.SetDiversity(SpiderDiversity.Void);
        GetComponent<Renderer>().material = initialMaterial;
    }

    public override void RemoveHighlight()
    {
        if (GetComponent<Renderer>() == null)
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = revertedMaterial;

        else GetComponent<Renderer>().material = revertedMaterial;
    }
}
