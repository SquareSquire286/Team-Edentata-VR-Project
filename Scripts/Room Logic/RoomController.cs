using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<GameObject> roomParameters;
    public GameObject regulatedObject, glassPane;
    public AudioSource speaker;
    public AudioClip incomplete, transitionClip;
    public Material clearGlass;
    public List<bool> conditions;

    public virtual void Start()
    {
        conditions = new List<bool>();
        speaker.clip = incomplete;

        foreach (GameObject paramater in roomParameters)
            conditions.Add(false);

        regulatedObject.GetComponent<AbstractGrabbable>().enabled = false;
        regulatedObject.GetComponent<Collider>().enabled = false; // ensures that the doorknob won't highlight if it's not currently grabbable
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

        if (CheckRoomConditions_NoRoomChanges())
            Debug.Log("Everything's done - waiting for transition button to be hit");
    }

    public virtual bool CheckRoomConditions()
    {
        foreach (bool condition in conditions)
            if (!condition)
                return false;

        regulatedObject.GetComponent<AbstractGrabbable>().enabled = true;
        regulatedObject.GetComponent<Collider>().enabled = true; // activates the highlight on hover, since the doorknob can actually be grabbed now
        glassPane.GetComponent<Renderer>().material = clearGlass;
        speaker.clip = transitionClip;
        return true;
        // Play audio clip of a door unlocking
    }

    private bool CheckRoomConditions_NoRoomChanges()
    {
        foreach (bool condition in conditions)
            if (!condition)
                return false;

        speaker.clip = transitionClip;
        return true;
    }
}
