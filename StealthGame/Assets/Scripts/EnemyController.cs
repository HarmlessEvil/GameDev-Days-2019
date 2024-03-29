﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Rendering.PostProcessing;

public class EnemyController : MonoBehaviour
{
    public bool isHunting;
    public float maxHuntingTime = 3f;
    public Transform player;
    public ScoreManager scoreManager;
    public SoundManager soundManager;
    public GameObject gameOver;

    float currentHuntingTime;

    IAstarAI ai;

    Animator animator;
    float lastHorizontal, lastVertical;

    public PostProcessVolume volume;
    ChromaticAberration ca = null;

    Patrol patrol;

    public Transform GetPlayer()
    {
        return player;
    }

    public Vector3 GetDesiredVelocity()
    {
        return ai.desiredVelocity;
    }

    void Start()
    {
        ai = GetComponent<IAstarAI>();
        animator = GetComponent<Animator>();
        gameOver = GameObject.FindGameObjectsWithTag("GameOver")[0];

        volume.profile.TryGetSettings(out ca);

        patrol = GetComponent<Patrol>();
    }

    void Update()
    {
        if (isHunting)
        {
            ai.destination = player.position;
            ai.maxSpeed = 0.9f;
            currentHuntingTime += Time.deltaTime;

            if (currentHuntingTime >= maxHuntingTime)
            {
                patrol.enabled = true;
                isHunting = false;
                ai.maxSpeed = 0.5f;

                var girl = player.gameObject.GetComponent<GirlMovement>();
                girl.StopChasing();

                if (!girl.IsChased())
                {
                    soundManager.PlayAmbientMusic();
                    ca.enabled.value = false;
                }
            }
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

    public void StartHunting()
    {
        if (!isHunting)
        {
            scoreManager.AddScore(-300);
            player.gameObject.GetComponent<GirlMovement>().StartChasing();
            soundManager.PlayBattleMusic();
            ca.enabled.value = true;
            patrol.enabled = false;
        }

        isHunting = true;
        currentHuntingTime = 0;
    }

    public void CatchPlayer()
    {
        Vector2 direction = player.position - transform.position;
        RaycastHit2D raycastHit = Physics2D.Raycast(
            transform.position,
            direction,
            float.PositiveInfinity,
            LayerMask.GetMask("Player", "Obstacles")
        );

        if (raycastHit && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            gameOver.GetComponent<GameOver>().Show();
            player.gameObject.GetComponent<GirlMovement>().Die();
        }
    }
}
