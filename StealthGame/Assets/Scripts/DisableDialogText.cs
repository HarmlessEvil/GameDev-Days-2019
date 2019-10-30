using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableDialogText : MonoBehaviour
{
    float time = 0.0f;
    public Text dialog;
    void Update()
    {
        if (dialog.text.Length > 0)
        {
            time += Time.deltaTime;
            if (time > 10.0f)
            {
                dialog.text = "";
                time = 0.0f;
            }
        }  
    }
}
