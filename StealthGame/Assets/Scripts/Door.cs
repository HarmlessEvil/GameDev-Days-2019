using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int ID;
    Animator animator;
    Collider2D colld;

    void Start()
    {
        Debug.Log("shit is here!");
        animator = GetComponent<Animator>();
        colld = GetComponent<Collider2D>();
        animator.Play("Idle");
    }

    void Update()
    {
        Debug.Log("Door id is " + ID.ToString());

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Inventory inv = other.gameObject.GetComponent<Inventory>();
            if (inv.Exs(ID, 1))
            {
                animator.Play("DoorOpen");
                colld.isTrigger = true;
            }
        }
        Debug.Log("Need key: " + ID.ToString());
    }
}
