using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpider : AbstractSpider
{
    // Start is called before the first frame update
    void Start()
    {
        selfTag = "BasicSpider";
        movementSpeed = 0.2f;
        rotationSpeedMagnifier = 0.75f;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("ChooseAction", 0f, 5f);
    }

    public override void Idle()
    {
        animator.SetBool("StartIdle", true);
        animator.SetBool("StartWalking", false);

        beginMovement = false;
        rigidbody.velocity = Vector3.zero;
    }

    public override void Move()
    {
        animator.SetBool("StartIdle", false);
        animator.SetBool("StartWalking", true);

        int choice = Random.Range(-180, 181);
        updatedOrientation = new Vector3(transform.rotation.x, transform.rotation.y + choice, transform.rotation.z);

        beginMovement = true;

        if (!hitWall)
        {
            leftWall = true;
        }
    }

    public override void OnTriggerEnter(Collider col)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(90, 271), transform.rotation.eulerAngles.z);
        hitWall = true;
        leftWall = false;
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == wallTag || col.gameObject.tag == selfTag)
        {
            hitWall = false;
        }
    }
}