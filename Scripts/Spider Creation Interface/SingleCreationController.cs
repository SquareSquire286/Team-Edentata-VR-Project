using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCreationController : AbstractButton
{
    public SpiderCreatorModel model;

    public override void OnPress()
    {
        transform.position = pressedPosition;

        if (model.GetRemainingSpiders() != 0)
            model.CreateSpider();
    }

    public override void OnRelease()
    {
        transform.position = releasedPosition;
    }
}
