using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public ScoreManager manager;
    public Text text;
    public Text mainText;
    public Text restartText;

    void Start()
    {
        text.enabled = false;
        mainText.enabled = false;
        restartText.enabled = false;
        GetComponent<Image>().enabled = false;
    }

    public void Show()
    {
        text.enabled = true;
        mainText.enabled = true;
        restartText.enabled = true;
        GetComponent<Image>().enabled = true;
        text.text = "Your score: " + manager.Score().ToString();
    }
}
