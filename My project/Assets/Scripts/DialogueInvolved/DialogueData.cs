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
        TextData.Add(100, new string[] { "4�ð� �Ѿ��µ�", "�� �ڰ��ִ� �� �λ��� ������", "�� ��ħ �Ծ�ߵǴµ�", "�̷��� �ʰ��ڸ� ����ɸԾ� ������" });
    }
}
