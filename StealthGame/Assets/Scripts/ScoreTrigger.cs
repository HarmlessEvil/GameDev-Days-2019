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
        Debug.Log("I'm triggered!");
        if (obj.gameObject == player && !triggered)
        {
            triggered = true;
            Debug.Log("I'm triggered!KKKK");
            EmptyScoreObj.TriggerTimer(3000);
        }
    }
}
