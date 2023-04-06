using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class Planning : MonoBehaviour
{
    int plannedAction = -1;         
    public GameObject objDiary;
    bool check = false;             //go ��ư Ȱ��ȭ üũ�� bool ����

    public string ActionString; //action�� Ŭ������ �� �÷��ʿ� ������ ���ڿ� ����
    public void OnSchedule()                //click �� ����
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; // ������ Diary
        plannedAction = objDiary.GetComponent<Diary>().selectedActionItemIndex; // ������ action �� index�� plannedAction ������ ����
        Diary.actionList[transform.parent.transform.GetSiblingIndex()][transform.GetSiblingIndex()] = plannedAction; // Diary�� ���� �� plannedAction ������ ����

        PrintActionName();                                    //text ��� switch�� �Լ�
        Go();                                                 //�÷� �ϼ� �� go��ư Ȱ��ȭ
        
    }
    void Go()                                                 //check ������ List�� �� ä�������� Ȯ�� �� go ��ư�� Ȱ��ȭ
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < Diary.actionList[i].Count; j++)
            {
                if (Diary.actionList[i][j] == -1)
                {
                    check = false;
                    return;                              
                }
                else
                    check = true; 
            }

        }
        if (check)
        {
            objDiary.transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    public void PrintActionName()
    {
        switch (plannedAction)
        {
            case -1:
                ActionString = "";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 0:
                ActionString = "���� ����";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 1:
                ActionString = "�";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 2:
                ActionString = "����";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 3:
                ActionString = "�޽�";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 4:
                ActionString = "����";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 5:
                ActionString = "�Ƹ�����Ʈ";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
        }
    }
}

