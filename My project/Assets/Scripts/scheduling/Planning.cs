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

    public string ActionString; //action을 클릭했을 때 플래너에 전달할 문자열 변수
    public void OnSchedule()
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; // 무조건 Diary
        plannedAction = objDiary.GetComponent<Diary>().selectedActionItemIndex; // 선택한 action 의 index를 plannedAction 변수에 저장
        Debug.Log(this.gameObject.name);
        objDiary.GetComponent<Diary>().actionList[transform.parent.transform.GetSiblingIndex()][transform.GetSiblingIndex()] = plannedAction; // Diary의 2차원 배열에 plannedAction 변수값 저장


        execute();

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




        if (objDiary.GetComponent<Diary>().weekPlan.Count == 7)
        {
            objDiary.transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    void execute() {
        objDiary.GetComponent<Diary>().weekPlan.Clear();
        Debug.Log("주간일정 초기화"+objDiary.GetComponent<Diary>().weekPlan.Count);
        for (int i = 0; i < 7; i++) {
            if (Array.Exists(objDiary.GetComponent<Diary>().actionList[i], el => el == -1) == false)
            {
                foreach (int action in objDiary.GetComponent<Diary>().actionList[i])
                {
                    objDiary.GetComponent<Diary>().dayPlan.Enqueue(action);
                }
                objDiary.GetComponent<Diary>().weekPlan.Enqueue(objDiary.GetComponent<Diary>().dayPlan);
                Debug.Log("하루일정은"+ objDiary.GetComponent<Diary>().dayPlan.Count);
                objDiary.GetComponent<Diary>().dayPlan.Clear();
                Debug.Log("하루 일정 초기화" + objDiary.GetComponent<Diary>().dayPlan.Count);
            }
            else
                break;
        }
    }
}

