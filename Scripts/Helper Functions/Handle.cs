using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: Used to maneuver doors
//
// Class Variables: 
//          target -> set to the invisible handle
//          rigidBody ->
// ***********************************************************************
public class Handle : MonoBehaviour
{
    public Transform target; 
    private Rigidbody rigidbody;



    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }


    // ************************************************************
    // Functionality: Update is called once per frame
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Update()
    {
        rigidbody.MovePosition(target.transform.position); 
    }
}
