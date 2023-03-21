using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Planning : MonoBehaviour
{
    int plannedAction;
    public GameObject objDiary;
    public void OnSchedule()
    {
        objDiary = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; // 무조건 Diary
        plannedAction = objDiary.GetComponent<Diary>().selectedActionItemIndex;
        objDiary.GetComponent<Diary>().actionList[transform.parent.transform.GetSiblingIndex()][transform.GetSiblingIndex()] = plannedAction;
        execute();
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

