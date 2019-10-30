using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject player;
    private bool triggered = false;
    public ScoreManager EmptyScoreObj;
    public GameOver gameOver;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player && !triggered)
        {
            triggered = true;
            EmptyScoreObj.StopTimer();

            gameOver.Show();
            player.GetComponent<GirlMovement>().Die();
        }
    }
}
