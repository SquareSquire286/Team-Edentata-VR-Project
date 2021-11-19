using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassCreationController : AbstractButton
{
    public SpiderCreatorModel model;

    public override void OnPress()
    {
        transform.position = pressedPosition;

        for (int i = 0; i < model.GetRemainingSpiders(); i++)
            model.CreateSpider();
    }

    public override void OnRelease()
    {
        transform.position = releasedPosition;
    }
}
