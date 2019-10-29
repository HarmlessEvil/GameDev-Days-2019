using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
  public void Start_Game()
    {
        SceneManager.LoadScene(1);
    }

  public void Settings(GameObject settings)
    {
       settings.SetActive(!settings.activeSelf);
    }

  public void Exit()
    {
        Application.Quit();
    }

  public void setMusic(float value)
    {
        Singletone.music = value;
    }
  public void setSound(float value)
    {
        Singletone.sound = value;
    }
}
