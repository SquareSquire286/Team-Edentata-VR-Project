using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDeletionController : AbstractButton
{
    public SpiderCreatorModel model;

    public override void OnPress()
    {
        transform.position = pressedPosition;

        if (model.GetRemainingSpiders() != SpiderCreatorSingleton.maxSpiders)
            model.RemoveSpider();
    }

    public override void OnRelease()
    {
        transform.position = releasedPosition;
    }
}
