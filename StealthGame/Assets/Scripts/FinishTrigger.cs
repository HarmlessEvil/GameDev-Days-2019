using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject player;
    private bool triggered = false;
    public ScoreManager EmptyScoreObj;
    public GameOver gameOver;
    public Leaderboard board;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player && !triggered)
        {
            triggered = true;
            EmptyScoreObj.StopTimer();

            gameOver.Show();
            player.GetComponent<GirlMovement>().Die();

            board.AddPlayer("Player1", EmptyScoreObj.Score());
        }
    }
}
