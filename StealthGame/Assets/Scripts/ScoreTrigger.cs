using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class ScoreTrigger : MonoBehaviour
{
    public GameObject player;
    private bool triggered = false;
    public ScoreManager EmptyScoreObj;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player && !triggered)
        {
            triggered = true;
            EmptyScoreObj.TriggerTimer(3000);
        }
    }
}
