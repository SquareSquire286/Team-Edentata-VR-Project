using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ***********************************************************************
// Purpose: 
//
// Class Variables: 
//          hitPlayer ->
//   
//
// ***********************************************************************
public class ComplexSpider : AbstractSpider
{
    private bool hitPlayer;


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void ChooseAction()
    {
        if (hitPlayer)
        {
            return;
        }
        else
        {
            int choice = Random.Range(0, 4);

            switch (choice)
            {
                case 0: Attack(); break;
                case 1: Idle(); break;
                case 2: Move(); break;
                default: Jump(); break;
            }
        }
    }

    
    // ************************************************************
    // Functionality: Start is called before the first frame update
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void Start()
    {
        selfTag = "ComplexSpider";
        movementSpeed = 0.25f;
        rotationSpeedMagnifier = 0.8f;
        hitPlayer = false;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("ChooseAction", 0f, 4f);
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    void ResetAfterPlayerHit()
    {
        hitPlayer = false;
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void Idle()
    {
        animator.SetBool("StartJump", false);
        animator.SetBool("StartIdle", true);
        animator.SetBool("StartWalking", false);
        animator.SetBool("StartAttack", false);

        beginMovement = false;
        rigidbody.velocity = Vector3.zero;

        Invoke("ResetAfterPlayerHit", 3f);
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void Move()
    {
        animator.SetBool("StartJump", false);
        animator.SetBool("StartIdle", false);
        animator.SetBool("StartWalking", true);
        animator.SetBool("StartAttack", false);

        int choice = Random.Range(-180, 181);
        updatedOrientation = new Vector3(transform.rotation.x, transform.rotation.y + choice, transform.rotation.z);

        beginMovement = true;

        if (!hitWall)
        {
            leftWall = true;
        }

        Invoke("ResetAfterPlayerHit", 3f);
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void Jump()
    {
        animator.SetBool("StartJump", true);
        animator.SetBool("StartIdle", false);
        animator.SetBool("StartWalking", false);
        animator.SetBool("StartAttack", false);

        beginMovement = false;
        rigidbody.velocity = Vector3.zero;

        Invoke("Move", 1.5f);
        Invoke("ResetAfterPlayerHit", 3f);
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: none
    // return: none
    // ************************************************************
    public override void Attack()
    {
        animator.SetBool("StartJump", false);
        animator.SetBool("StartIdle", false);
        animator.SetBool("StartWalking", false);
        animator.SetBool("StartAttack", true);

        beginMovement = false;
        rigidbody.velocity = Vector3.zero;

        Invoke("Move", 1.5f);
        Invoke("ResetAfterPlayerHit", 3f);
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    public override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == playerTag || col.gameObject.tag == selfTag)
        {
            hitPlayer = true;

            int choice = Random.Range(0, 20);

            switch (choice % 4)
            {
                case 0: Attack(); break;
                case 1: Jump(); break;
                case 2: Move(); break;
                default: Idle(); break;
            }
        }
        else if (col.gameObject.tag == basicSpiderTag || col.gameObject.tag == intermediateSpiderTag)
        {
            hitPlayer = true;
            Attack();
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(90, 271), transform.rotation.eulerAngles.z);
            hitWall = true;
            leftWall = false;
        }
    }


    // ************************************************************
    // Functionality: 
    // 
    // Parameters: col
    // return: none
    // ************************************************************
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == wallTag || col.gameObject.tag == selfTag)
        {
            hitWall = false;
        }
    }
}