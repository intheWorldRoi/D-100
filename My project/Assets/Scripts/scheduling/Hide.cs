using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public GameObject diary;
    public GameObject desk;
    public GameObject playActions;

    public void HideDiary()          //exit ��ư���� ����
    {
        SoundManager.instance.PlaySound("click");
        diary.SetActive(false);
        desk.GetComponent<Button>().enabled = true;
    }

    public void HideAndReveal()      //Go ��ư�� �޷� �ְ� ��ư ������ ���̾ ����� ����ũ ����.
    {                                //����ũ�� ���̾ �θ����� ��ƾ �� �� ������ ����� ���̾, ����ũ �� �� ��Ȱ��ȭ
        SoundManager.instance.PlaySound("click");
        DialogueSystem.IsInAction = true;
        Debug.Log(Diary.actionList[0][0]);
        diary.SetActive(false);
        desk.SetActive(false);
        DialogueSystem.NewLoop = false;
        desk.GetComponent<Button>().enabled = true;
        

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
    public void exitBtn()              
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void openSetting()          
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
