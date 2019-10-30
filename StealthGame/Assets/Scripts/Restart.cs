using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Leaderboard leaderboardClass;
    public GameObject leaderboardPanel;

    void Update()
    {
        if (!Mathf.Approximately(Input.GetAxis("Restart"), 0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        leaderboardPanel.SetActive(!Mathf.Approximately(Input.GetAxis("Leaderboard"), 0));
        if (!Mathf.Approximately(Input.GetAxis("Leaderboard"), 0))
        {
            leaderboardClass.ApplyTop10();
        }
    }
}
