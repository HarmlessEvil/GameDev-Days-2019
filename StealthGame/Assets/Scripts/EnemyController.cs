using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public bool isHunting;
    public Transform player;

    IAstarAI ai;

    Animator animator;
    float lastHorizontal, lastVertical;

    void Start()
    {
        ai = GetComponent<IAstarAI>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isHunting)
        {
            ai.destination = player.position;
        }

        if (Mathf.Approximately(ai.desiredVelocity.x, 0f) && Mathf.Approximately(ai.desiredVelocity.y, 0f))
        {
            animator.SetFloat("LastHorizontalDirection", lastHorizontal);
            animator.SetFloat("LastVerticalDirection", lastVertical);
            animator.SetBool("IsMoving", false);
        }
        else
        {
            lastHorizontal = ai.desiredVelocity.x;
            lastVertical = ai.desiredVelocity.y;

            animator.SetBool("IsMoving", true);
        }

        animator.SetFloat("HorizontalDirection", ai.desiredVelocity.x);
        animator.SetFloat("VerticalDirection", ai.desiredVelocity.y);
    }
}
