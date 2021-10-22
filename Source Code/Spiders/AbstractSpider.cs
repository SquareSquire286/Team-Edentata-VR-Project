using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractSpider : MonoBehaviour
{
    public float movementSpeed;
    public Animator animator;
    public Rigidbody rigidbody;
    public string playerTag, wallTag, selfTag;

    public void ChooseAction()
    {
        int choice = Random.Range(0, 3);

        switch (choice)
        {
            case 0: Idle(); break;
            default: Move(); break;
        }
    }

    public virtual void Idle()
    {
        // Defined in concrete subclasses.
    }

    public virtual void Move()
    {
        // Defined in concrete subclasses.
    }

    public virtual void Attack()
    {
        // Defined in concrete subclasses.
    }

    public virtual void OnTriggerEnter(Collider col)
    {
        // Checks proximity to player and chooses an action
        // Should also check for a wall and choose a new direction vector > 90 degrees from their current direction vector

        if (col.gameObject.tag == playerTag)
        {
            Debug.Log("Sensed player");
        }

        else if (col.gameObject.tag == wallTag)
        {
            Debug.Log("Sensed wall");
        }
    }
}
