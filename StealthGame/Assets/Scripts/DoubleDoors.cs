using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoors : MonoBehaviour
{
    public int ID;

    void Start()
    {
        GameObject panel = this.gameObject.transform.GetChild(0).gameObject;
        GameObject left = this.gameObject.transform.GetChild(1).gameObject;
        GameObject right = this.gameObject.transform.GetChild(2).gameObject;

        Color color = Key.DEFAULT_COLORS[ID];
        panel.GetComponent<SpriteRenderer>().material.SetColor("_Color", color);
        left.GetComponent<Door>().ID = ID;
        right.GetComponent<Door>().ID = ID;
    }
}
