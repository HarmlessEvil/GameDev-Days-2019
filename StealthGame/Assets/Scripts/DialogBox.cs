using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public GameObject player;
    private bool triggered = false;
    public Text dialogText;
    public string phrase;

    void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log("I'm triggered!");
        if (obj.gameObject == player && !triggered)
        {
            triggered = true;
            dialogText.text = phrase;
        }
    }
}
