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
    bool check = false;

    public string ActionString; //action을 클릭했을 때 플래너에 전달할 문자열 변수
    public void OnSchedule()
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; // 무조건 Diary
        plannedAction = objDiary.GetComponent<Diary>().selectedActionItemIndex; // 선택한 action 의 index를 plannedAction 변수에 저장
        Diary.actionList[transform.parent.transform.GetSiblingIndex()][transform.GetSiblingIndex()] = plannedAction; // Diary의 이중 에 plannedAction 변수값 저장

        switch (plannedAction)
        {
            case 0:
                ActionString = "토익 공부";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;

                break;
            case 1:
                ActionString = "운동";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 2:
                ActionString = "독서";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 3:
                ActionString = "휴식";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 4:
                ActionString = "외출";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
            case 5:
                ActionString = "아르바이트";
                this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ActionString;
                break;
        }

        //execute();
        Go();
        
    }
    void Go()
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
}

