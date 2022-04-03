using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermediateSpider : AbstractSpider
{
    private bool hitPlayer;

    public override void ChooseAction()
    {
        if (hitPlayer)
            return;

        else
        {
            int choice = Random.Range(0, 5);

            switch (choice)
            {
                case 0:
                case 1:
                case 2: Move(); break;
                default: Jump(); break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        selfTag = "IntermediateSpider";
        movementSpeed = 0.225f;
        rotationSpeedMagnifier = 0.75f;
        hitPlayer = false;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("ChooseAction", 0f, 4.5f);
    }

    void ResetAfterPlayerHit()
    {
        hitPlayer = false;
    }

    public override void Idle()
    {
        animator.SetBool("StartJump", false);
        animator.SetBool("StartIdle", true);
        animator.SetBool("StartWalking", false);

        beginMovement = false;
        rigidbody.velocity = Vector3.zero;

        Invoke("ResetAfterPlayerHit", 3f);
    }

    public override void Move()
    {
        animator.SetBool("StartJump", false);
        animator.SetBool("StartIdle", false);
        animator.SetBool("StartWalking", true);

        int choice = Random.Range(-180, 181);
        updatedOrientation = new Vector3(transform.rotation.x, transform.rotation.y + choice, transform.rotation.z);

        beginMovement = true;

        if (!hitWall)
            leftWall = true;

        Invoke("ResetAfterPlayerHit", 3f);
    }

    public override void Jump()
    {
        animator.SetBool("StartJump", true);
        animator.SetBool("StartIdle", false);
        animator.SetBool("StartWalking", false);

        beginMovement = false;
        rigidbody.velocity = Vector3.zero;

        Invoke("Move", 1f);
        Invoke("ResetAfterPlayerHit", 3f);
    }

    public override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == wallTag || col.gameObject.tag == complexSpiderTag || col.gameObject.tag == extremeSpiderTag)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(90, 271), transform.rotation.eulerAngles.z);
            hitWall = true;
            leftWall = false;
        }

        else if (col.gameObject.tag == playerTag || col.gameObject.tag == selfTag)
        {
            hitPlayer = true;

            int choice = Random.Range(0, 20);

            if (choice % 2 == 0) // Cases 0, 2, 4, 6, 8, 10, 12, 14, 16, and 18
                Move();

            else if (choice != 1) // Cases 3, 5, 7, 9, 11, 13, 15, 17, and 19
                Idle();

            else Jump(); // Case 1
        }

        // else if basic spider, do nothing
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == wallTag || col.gameObject.tag == selfTag)
        {
            hitWall = false;
        }
    }
}
