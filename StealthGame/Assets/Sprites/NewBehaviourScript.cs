using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
 
  public void Start_Game()
    {
        Application.LoadLevel(1);
    }

  public void Settings(GameObject settings)
    {
       settings.SetActive(!settings.activeSelf);
    }

  public void Load_Game()
    {
        // надо ли оно нам?
    }

  public void Exit()
    {
        DontDestroyOnLoad(gameObject);

        Application.Quit();     

    }

  public void setMusic(float value)
    {
        global.music = value;
    }
   public void setSound(float value)
    {
        global.sound = value;
    }

}
