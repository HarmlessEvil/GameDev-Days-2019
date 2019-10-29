using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public GameObject scrollBar;
    public Text letterText;
    Animator animator;
    SpriteRenderer m_renderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Idle");
        scrollBar.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.Play("KeyPicking");
            scrollBar.SetActive(true);
            letterText.text = "\n\n\n\n\n\n\nLOREM IPSUM";
            Destroy(this.gameObject, 0.5f);
        }
    }
}
