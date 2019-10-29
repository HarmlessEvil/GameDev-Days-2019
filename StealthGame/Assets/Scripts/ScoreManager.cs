using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private bool triggered;
    private int tick;
    private int scores;
    
    void Start()
    {
        scores = 0;
        tick = 0;
    }

    public void TriggerTimer(int score)
    {
        triggered = true;

        tick = 0;
        scores += score;
    }

    void Update()
    {
        tick += 1;
        if (triggered && tick % 30 == 0)
        {
            scores -= 1;
            //Debug.Log(scores.ToString());
            tick = 0;
        }
        
        if (scores <= 0)
        {
            scores = 0;
        }
    }

    public int Score()
    {
        return scores;
    }

    public void AddScore(int score)
    {
        scores += score;
    }

    public void StopTimer()
    {
        triggered = false;
    }
}
