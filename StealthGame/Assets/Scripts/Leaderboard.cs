using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Text.RegularExpressions;

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
    public Text users;
    public Text scores;

    private string fileName = "board.json";
    private List<Person> board = new List<Person>();
    private bool updated = false;

    public void AddPlayer(string name, int score)
    {
        if (!updated)
        {
            ReadLeaderboard();
        }
        board.Add(new Person(score, name));
        WriteLeaderboard();
    }

    public void ReadLeaderboard()
    {
        updated = true;
        string filePath = Application.dataPath + fileName;

        string json = "";
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
        }

        board = new List<Person>();
        foreach (string person in Regex.Split(json, @"\|"))
        {
            if (person == "") break;
            Person ps = JsonUtility.FromJson<Person>(person);
            AddPlayer(ps.name, ps.score);
        }

        board.Sort((p1, p2) => p2.score.CompareTo(p1.score));
    }

    public void WriteLeaderboard()
    {
        if (updated)
        {
            string json = "";
            foreach (Person person in board)
            {
                json += JsonUtility.ToJson(person) + "|";
            }
            string filePath = Application.dataPath + fileName;
            File.WriteAllText(filePath, json);
        }
    }

    public void ApplyTop10()
    {
        ReadLeaderboard();

        string userst = "", scorest = "";
        int count = 0;
        foreach (Person person in board)
        {
            userst += person.name + '\n';
            scorest += person.score.ToString() + '\n';
            count++;
            if (count == 10) break;
        }

        users.text = userst;
        scores.text = scorest;
    }

    void Start()
    {
        ReadLeaderboard();
    }
}
