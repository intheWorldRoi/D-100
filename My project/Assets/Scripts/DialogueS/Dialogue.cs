using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{

    public string name;
    public List<string> sentences;

    public Dialogue(string name, string[] s)
    {
        this.name = name;
        for (int i = 0; i < s.Length; i++)
            sentences.Add(s[i]);
    }


    public int Add(string name, string[] s)
    {
        return 0;
    }
}
