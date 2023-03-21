using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Planning : MonoBehaviour
{
    int plannedAction;

    
    GameObject objDiary;
    private void OnMouseDown()
    {
        
        objDiary = transform.parent.gameObject.transform.parent.gameObject; // 무조건 Diary
        plannedAction = objDiary.GetComponent<Diary>().selectedActionItemIndex;
        objDiary.GetComponent<Diary>().actionList[transform.GetSiblingIndex()] = plannedAction;
        if (Array.Exists(objDiary.GetComponent<Diary>().actionList, el => el == -1) == false)
        {
            Debug.Log("실행");
            foreach(int action in objDiary.GetComponent<Diary>().actionList)
            {
                objDiary.GetComponent<Diary>().schedule.Enqueue(action);
            }
            foreach (int action in objDiary.GetComponent<Diary>().schedule)
            {
                Debug.Log(action);
            }
        }
        
    }
}
