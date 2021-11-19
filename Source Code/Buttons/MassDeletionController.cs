using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassDeletionController : AbstractButton
{
    public SpiderCreatorModel model;

    public override void OnPress()
    {
        transform.position = pressedPosition;

        model.RemoveAllSpiders();
    }

    public override void OnRelease()
    {
        transform.position = releasedPosition;
    }
}
