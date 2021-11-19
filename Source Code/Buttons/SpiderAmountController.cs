using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAmountController : AbstractButton
{
    public SpiderCreatorModel model;
    public int amountModifier;

    public override void OnPress()
    {
        transform.position = pressedPosition;
        Debug.Log(gameObject.name + " pressed");
        model.ChangeMaxAmount(amountModifier);
    }

    public override void OnRelease()
    {
        transform.position = releasedPosition;
    }
}
