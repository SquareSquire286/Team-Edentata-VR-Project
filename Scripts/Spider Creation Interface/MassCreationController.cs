using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassCreationController : AbstractButton
{
    public SpiderCreatorModel model;

    public override void OnPress()
    {
        transform.position = pressedPosition;
        int spiderLimit = model.GetRemainingSpiders();

        model.CreateAllSpiders(spiderLimit);
    }

    public override void OnRelease()
    {
        transform.position = releasedPosition;
    }
}
