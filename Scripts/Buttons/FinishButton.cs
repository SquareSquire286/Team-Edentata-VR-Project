using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : AbstractButton
{
    public override void OnPress()
    {
        transform.position = pressedPosition;

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
