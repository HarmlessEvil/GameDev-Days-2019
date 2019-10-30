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
        animator = GetComponent<Animator>();
        colld = GetComponent<Collider2D>();
        animator.Play("Idle");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Inventory inv = other.gameObject.GetComponent<Inventory>();
            if (ID >= Key.DEFAULT_COLORS.Length || inv.Exs(ID, 1))
            {
                animator.Play("DoorOpen");
                colld.isTrigger = true;

                FindObjectOfType<ScoreManager>().AddScore(10);
            }
        }
    }
}
