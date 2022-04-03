using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticReceiver : MonoBehaviour
{
    public Controller controller;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<HapticGenerator>() != null) // indicates collision with a spider
        {
            HapticGenerator generator = col.gameObject.GetComponent<HapticGenerator>();

            if (controller.GetHand() == Hand.Left)
                OVRInput.SetControllerVibration(generator.GetFrequency(), generator.GetAmplitude(), OVRInput.Controller.LTouch);

            else OVRInput.SetControllerVibration(generator.GetFrequency(), generator.GetAmplitude(), OVRInput.Controller.RTouch);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<HapticGenerator>() != null) // indicates collision with a spider
        {
            if (controller.GetHand() == Hand.Left)
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);

            else OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }
}
