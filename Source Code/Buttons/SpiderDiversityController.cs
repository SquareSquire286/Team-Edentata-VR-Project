using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDiversityController : AbstractButton
{
    public SpiderDiversity diversity;
    public SpiderCreatorModel model;
    public List<SpiderDiversityController> otherDiversityButtons;
    public Material initialMaterial, pressedMaterial;

    public override void OnPress()
    {
        transform.position = pressedPosition;

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
        model.SetDiversity(SpiderDiversity.Void);
        GetComponent<Renderer>().material = initialMaterial;
    }
}
