using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIntensityController : AbstractButton
{
    public SpiderIntensity intensity;
    public SpiderCreatorModel model;
    public List<SpiderIntensityController> otherIntensityButtons;
    public Material initialMaterial, pressedMaterial;

    public override void OnPress()
    {
        transform.position = pressedPosition;

        foreach (SpiderIntensityController button in otherIntensityButtons)
            button.Reset();

        model.SetIntensity(intensity);
        GetComponent<Renderer>().material = pressedMaterial;
    }

    public override void OnRelease()
    {
        if (model.GetIntensity() != intensity)
            transform.position = releasedPosition;
    }

    public void Reset()
    {
        transform.position = releasedPosition;
        model.SetIntensity(SpiderIntensity.Void);
        GetComponent<Renderer>().material = initialMaterial;
    }
}
