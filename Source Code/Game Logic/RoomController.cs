using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<GameObject> roomParameters;
    public GameObject regulatedObject;
    public List<bool> conditions;

    public virtual void Start()
    {
        conditions = new List<bool>();

        foreach (GameObject paramater in roomParameters)
            conditions.Add(false);

        regulatedObject.GetComponent<AbstractGrabbable>().enabled = false;
    }

    public virtual void Update()
    {

    }

    public virtual void UpdateRoomConditions(GameObject gameObject)
    {
        foreach (GameObject parameter in roomParameters)
        {
            if (parameter == gameObject)
                conditions[roomParameters.IndexOf(parameter)] = true;
        }
    }

    public virtual void CheckRoomConditions()
    {
        foreach (bool condition in conditions)
            if (!condition)
                return;

        regulatedObject.GetComponent<AbstractGrabbable>().enabled = true;
        // Play audio clip of a door unlocking
    }
}
