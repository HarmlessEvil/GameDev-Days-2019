using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    int amountOfChasers = 0;

    Animator animator;
    float lastHorizontal, lastVertical;

    Rigidbody2D rb;

    Vector2 movement;

    public void StartChasing()
    {
        ++amountOfChasers;
    }

    public void StopChasing()
    {
        --amountOfChasers;
    }

    public bool IsChased()
    {
        return amountOfChasers > 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement.Normalize();

        if (Mathf.Approximately(movement.x, 0f) && Mathf.Approximately(movement.y, 0f))
        {
            animator.SetFloat("LastHorizontalDirection", lastHorizontal);
            animator.SetFloat("LastVerticalDirection", lastVertical);
            animator.SetBool("IsMoving", false);
        }
        else
        {
            lastHorizontal = movement.x;
            lastVertical = movement.y;

            animator.SetBool("IsMoving", true);
        }

        animator.SetFloat("HorizontalDirection", movement.x);
        animator.SetFloat("VerticalDirection", movement.y);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
