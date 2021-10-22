using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: Used to maneuver doors
public class Handle : MonoBehaviour
{
    public Transform target; // set to the invisible handle
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(target.transform.position); 
    }
}
