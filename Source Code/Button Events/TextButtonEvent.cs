using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextButtonEvent : AbstractButtonEvent
{
    private Text text;

    // Start is called before the first frame update
    public override void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }

    public override void ExecuteEvent()
    {
        text.enabled = true;
    }

    public override void StopEvent()
    {
        text.enabled = false;
    }
}
