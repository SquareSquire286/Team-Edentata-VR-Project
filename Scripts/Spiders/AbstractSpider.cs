using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          movementSpeed ->
//          animator ->
//          rigidbody ->
//          selfTag ->
//          beginMovement ->
//          hitWall ->
//          leftWall ->
//          updatedOrientation ->
//          rotationSpeedMagnifier ->
//          #Tag ->
//   
//
// ***********************************************************************
public class AbstractSpider : MonoBehaviour
{
    protected float movementSpeed;
    protected Animator animator;
    protected Rigidbody rigidbody;
    protected string selfTag;
    protected bool beginMovement, hitWall, leftWall;
    protected Vector3 updatedOrientation;
    protected float rotationSpeedMagnifier;
    protected string playerTag = "Player", wallTag = "Wall", basicSpiderTag = "BasicSpider", intermediateSpiderTag = "IntermediateSpider", complexSpiderTag = "ComplexSpider", extremeSpiderTag = "ExtremeSpider";


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void ChooseAction()
    {
        int choice = Random.Range(0, 3);

        switch (choice)
        {
            case 0: Idle(); break;
            default: Move(); break;
        }
    }


    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void Start()
    {
        
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void FixedUpdate()
    {
        if (beginMovement)
        {
            if (!hitWall && leftWall)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(updatedOrientation.x, updatedOrientation.y, updatedOrientation.z), movementSpeed * rotationSpeedMagnifier * Time.deltaTime);
            }

            rigidbody.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void Idle()
    {
        // Defined in concrete subclasses.
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void Move()
    {
        // Defined in concrete subclasses.
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void Jump()
    {

    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public virtual void Attack()
    {
        // Defined in concrete subclasses.
    }


    // ************************************************************
    // Functionality: Checks proximity to player and chooses an action. 
    //                Should also check for a wall and choose a new 
    //                direction vector > 90 degrees from their current 
    //                direction vector
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    public virtual void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == playerTag)
        {
            Debug.Log("Sensed player");
        }
        else if (col.gameObject.tag == wallTag)
        {
            Debug.Log("Sensed wall");
        }
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    public virtual void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == wallTag || col.gameObject.tag == selfTag)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(90, 271), transform.rotation.eulerAngles.z);
        }
    }
}
