using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PressButton", 1f);  
    }

    public void PressButton()
    {
        if (this.gameObject.GetComponent<SpiderIntensityController>() != null)
            this.gameObject.GetComponent<SpiderIntensityController>().OnPress();

        else this.gameObject.GetComponent<SpiderDiversityController>().OnPress();
    }
}
