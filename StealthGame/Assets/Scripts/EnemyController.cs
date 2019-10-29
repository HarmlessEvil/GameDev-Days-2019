using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public bool isHunting;
    public float maxHuntingTime = 15f;
    public Transform player;
    public ScoreManager scoreManager;
    public SoundManager soundManager;
    public GameObject gameOver;

    float currentHuntingTime;

    IAstarAI ai;

    Animator animator;
    float lastHorizontal, lastVertical;

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
    }

    void Update()
    {
        if (isHunting)
        {
            ai.destination = player.position;
            ai.maxSpeed = 1.1f;
            currentHuntingTime += Time.deltaTime;

            if (currentHuntingTime >= maxHuntingTime)
            {
                isHunting = false;
                ai.maxSpeed = 0.5f;

                var girl = player.gameObject.GetComponent<GirlMovement>();
                girl.StopChasing();

                Debug.Log("Girl is " + (girl.IsChased() ? "" : "not") + "chased");

                if (!girl.IsChased())
                {
                    soundManager.PlayAmbientMusic();
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
        }

        isHunting = true;
        currentHuntingTime = 0;
    }

    public void CatchPlayer()
    {
        // Not implemented
        gameOver.GetComponent<GameOver>().Show();
    }
}
