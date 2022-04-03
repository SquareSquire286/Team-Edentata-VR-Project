using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hand
{
    Right,
    Left
}

public class Controller : MonoBehaviour
{
    [SerializeField] Hand hand;

    public Hand GetHand()
    {
        return hand;
    }
}
