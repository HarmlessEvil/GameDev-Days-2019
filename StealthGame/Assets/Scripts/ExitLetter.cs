using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLetter : MonoBehaviour
{
    public GameObject diarySprite;
    void Update()
    {
        if (Input.GetButton("Cancel") && !diarySprite)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
