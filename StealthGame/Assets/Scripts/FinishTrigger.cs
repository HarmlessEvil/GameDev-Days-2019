using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject player;
    private bool triggered = false;
    public ScoreManager EmptyScoreObj;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player && !triggered)
        {
            triggered = true;
            EmptyScoreObj.StopTimer();
            Debug.Log("Finish");
            Debug.Log(EmptyScoreObj.Score());
        }
    }
}
