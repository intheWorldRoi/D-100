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

    public GameObject[] ReviewObjects;
    public TextMeshProUGUI[] ReviewTexts;

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
        for(int i = 0; i < ReviewObjects.Length; i++)
        {
            ReviewObjects[i].GetComponent<Image>().color = new Color(ReviewObjects[i].GetComponent<Image>().color.r, 
                ReviewObjects[i].GetComponent<Image>().color.g, 
                ReviewObjects[i].GetComponent<Image>().color.b, 0);
        }
        for(int i = 0; i < ReviewTexts.Length; i++)
        {
            if(i < 3)
            {
                ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
            }
            else
            {
                ReviewTexts[i].GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }
    public void openSetting()          
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
