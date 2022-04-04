using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **************************************************************
// Purpose: A data class with an enumeration for the hand type, and
//          a simple getter for this hand type. This class must
//          be applied to the same objects to which Grabber.cs is
//          applied.
//***************************************************************
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
