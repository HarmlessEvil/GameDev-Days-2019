using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private bool triggered;
    private int tick;
    private int scores;
    // Start is called before the first frame update
    void Start()
    {
        scores = 3000;
        tick = 0;
    }

    public void TriggerTimer()
    {
        triggered = true;
        tick = 0;
    }

    void Update()
    {
        tick += 1;
        if (triggered && tick % 30 == 0)
        {
            scores -= 1;
            Debug.Log(scores.ToString());
            tick = 0;
        }
        
        if (scores <= 0)
        {
            //Application.Quit();
        }
    }

    public int Score()
    {
        return scores;
    }

    public void StopTimer()
    {
        triggered = false;
    }
}
