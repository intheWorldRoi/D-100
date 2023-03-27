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

    public void HideDiary()          //exit 버튼에서 쓰임
    {
        diary.SetActive(false);
    }
    public void HideAndReveal()      //Go 버튼에 달려 있고 버튼 누르면 다이어리 숨기고 데스크 숨김.
    {                                //데스크가 다이어리 부모지만 루틴 돌 때 꼬이지 말라고 다이어리, 데스크 둘 다 비활성화
        Debug.Log(Diary.actionList[0][0]);
        diary.SetActive(false);
        desk.SetActive(false);

        switch (Diary.actionList[0][0])
        {
            case 0:
                ActionManager.Toeic();
                playActions.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                ActionManager.Fitness();
                playActions.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                ActionManager.Reading();
                playActions.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                ActionManager.Rest();
                playActions.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 4:
                ActionManager.GoOut();
                playActions.gameObject.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 5:
                ActionManager.Partjob();
                playActions.gameObject.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }
        playActions.SetActive(true);      //goAction은 액션을 수행하는 오브젝트들의 부모.(연쇄작용 매개자 역할)

        
    }

    public void RemoveText()              //go 버튼 누를 시 플래너 텍스트 초기화
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
