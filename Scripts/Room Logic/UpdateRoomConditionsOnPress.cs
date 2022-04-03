using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRoomConditionsOnPress : MonoBehaviour
{
    private bool hasActivated;
    public Vector3 pressedPosition;
    public RoomController room0Controller;

    // Start is called before the first frame update
    void Start()
    {
        hasActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasActivated)
        {
            if (transform.position == pressedPosition)
            {
                room0Controller.UpdateRoomConditions(this.gameObject);
                hasActivated = true;
            }
        }
    }
}
