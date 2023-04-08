using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject diary;
    public GameObject desk;
    public GameObject playActions;

    public void HideDiary()          //exit ��ư���� ����
    {
        diary.SetActive(false);
    }

    public void HideAndReveal()      //Go ��ư�� �޷� �ְ� ��ư ������ ���̾ ����� ����ũ ����.
    {                                //����ũ�� ���̾ �θ����� ��ƾ �� �� ������ ����� ���̾, ����ũ �� �� ��Ȱ��ȭ
        DialogueSystem.IsInAction = true;
        Debug.Log(Diary.actionList[0][0]);
        diary.SetActive(false);
        desk.SetActive(false);
        DialogueSystem.NewLoop = false;
        

        playActions.SetActive(true);      //goAction�� �׼��� �����ϴ� ������Ʈ���� �θ�.(�����ۿ� �Ű��� ����)

        
    }

    public void RemoveText()              //go ��ư ���� �� �÷��� �ؽ�Ʈ �ʱ�ȭ
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < Diary.actionList[i].Count; j++)
            {
                diary.transform.GetChild(0).transform.GetChild(i).transform.GetChild(j).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            }

        }
    }
}
