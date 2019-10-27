using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


[Serializable]
public struct Person
{
    public int score;
    public string name;
    public Person(int score, string name)
    {
        this.score = score;
        this.name = name;
    }
}


public class Leaderboard : MonoBehaviour
{
    private string fileName = "board.json";
    private List<Person> board = new List<Person>();
    private bool updated = false;

    void AddPlayer(string name, int score)
    {
        if (!updated)
        {
            ReadLeaderboard();
        }
        board.Add(new Person(score, name));
        WriteLeaderboard();
    }

    void ReadLeaderboard()
    {
        string filePath = Application.dataPath + fileName;

        string json = "";
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
        }

        board = JsonUtility.FromJson<List<Person>>(json);
        updated = true;
    }

    void WriteLeaderboard()
    {
        if (updated)
        {
            string json = JsonUtility.ToJson(board);
            string filePath = Application.dataPath + fileName;
            File.WriteAllText(filePath, json);
        }
    }

    void Start() { }
    void Update() { }
}
