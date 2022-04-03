using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIntensityController : AbstractButton
{
    public SpiderIntensity intensity;
    public SpiderCreatorModel model;
    public List<SpiderIntensityController> otherIntensityButtons;
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
        revertedMaterial = initialMaterial;
        model.SetIntensity(SpiderIntensity.Void);
        GetComponent<Renderer>().material = initialMaterial;
    }

    public override void RemoveHighlight()
    {
        if (GetComponent<Renderer>() == null)
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = revertedMaterial;

        else GetComponent<Renderer>().material = revertedMaterial;
    }
}
