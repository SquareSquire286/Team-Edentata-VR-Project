using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticGenerator : MonoBehaviour
{
    [SerializeField] float frequency, amplitude;

    public float GetFrequency()
    {
        return frequency;
    }

    public float GetAmplitude()
    {
        return amplitude;
    }
}
