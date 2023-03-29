using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    string myname;

    Dictionary<int, string[]> TextData;

    

    private void Awake()
    {
        TextData = new Dictionary<int, string[]>();
    }

    private void OnMouseDown()
    {
        //TextData[100];
    }



    void GenerateData()
    {
        TextData.Add(100, new string[] { "4시가 넘었는데", "안 자고있는 내 인생이 레전드", "아 아침 먹어야되는데", "이렇게 늦게자면 어뜨케먹어 병신이" });
    }
}
