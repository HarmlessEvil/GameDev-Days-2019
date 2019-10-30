using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour
{
    public static Color[] DEFAULT_COLORS =
            { Color.black
            , Color.blue
            , Color.cyan
            , Color.gray
            , Color.green
            , Color.grey
            , Color.magenta
            , Color.red
            , Color.white
            , Color.yellow };
    public int ID;
    Animator animator;
    SpriteRenderer m_renderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();
        m_renderer.material.SetColor("_Color", DEFAULT_COLORS[ID]);
        animator.Play("Idle");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var inventory = other.gameObject.GetComponent<Inventory>();
            if (inventory)
            {
                inventory.Add(ID, 1);
                animator.Play("KeyPicking");
                Destroy(gameObject, 0.5f);

                FindObjectOfType<ScoreManager>().AddScore(30);
            }
        }
    }
}
