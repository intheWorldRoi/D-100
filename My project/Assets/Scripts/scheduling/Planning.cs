using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class Planning : MonoBehaviour
{
    int plannedAction;
    public GameObject objDiary;

    public string ActionString; //action�� Ŭ������ �� �÷��ʿ� ������ ���ڿ� ����
    public void OnSchedule()
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; // ������ Diary
        plannedAction = objDiary.GetComponent<Diary>().selectedActionItemIndex; // ������ action �� index�� plannedAction ������ ����
        Debug.Log(this.gameObject.name);
        objDiary.GetComponent<Diary>().actionList[transform.parent.transform.GetSiblingIndex()][transform.GetSiblingIndex()] = plannedAction; // Diary�� 2���� �迭�� plannedAction ������ ����


        execute();

        switch (plannedAction)
        {
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




        if (objDiary.GetComponent<Diary>().weekPlan.Count == 7)
        {
            objDiary.transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    void execute() {
        objDiary.GetComponent<Diary>().weekPlan.Clear();
        Debug.Log("�ְ����� �ʱ�ȭ"+objDiary.GetComponent<Diary>().weekPlan.Count);
        for (int i = 0; i < 7; i++) {
            if (Array.Exists(objDiary.GetComponent<Diary>().actionList[i], el => el == -1) == false)
            {
                foreach (int action in objDiary.GetComponent<Diary>().actionList[i])
                {
                    objDiary.GetComponent<Diary>().dayPlan.Enqueue(action);
                }
                objDiary.GetComponent<Diary>().weekPlan.Enqueue(objDiary.GetComponent<Diary>().dayPlan);
                Debug.Log("�Ϸ�������"+ objDiary.GetComponent<Diary>().dayPlan.Count);
                objDiary.GetComponent<Diary>().dayPlan.Clear();
                Debug.Log("�Ϸ� ���� �ʱ�ȭ" + objDiary.GetComponent<Diary>().dayPlan.Count);
            }
            else
                break;
        }
    }
}

