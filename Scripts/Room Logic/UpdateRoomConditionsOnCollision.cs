using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRoomConditionsOnCollision : MonoBehaviour
{
    public string headString;
    public RoomController roomController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == headString)
            roomController.UpdateRoomConditions(this.gameObject);
    }
}
