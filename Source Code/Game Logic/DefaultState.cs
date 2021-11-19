using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<SpiderIntensityController>() != null)
            this.gameObject.GetComponent<SpiderIntensityController>().OnPress();

        else this.gameObject.GetComponent<SpiderDiversityController>().OnPress();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
