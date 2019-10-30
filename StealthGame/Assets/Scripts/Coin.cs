using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    Animator animator;
    SpriteRenderer m_renderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var inventory = other.gameObject.GetComponent<Inventory>();
            if (inventory)
            {
                inventory.Add(0, 2);
                animator.Play("KeyPicking");
                Destroy(gameObject, 0.5f);

                FindObjectOfType<ScoreManager>().AddScore(100);
            }
        }
    }
}
