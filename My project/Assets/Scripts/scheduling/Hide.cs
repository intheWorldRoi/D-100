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

    public void HideDiary()          //exit 버튼에서 쓰임
    {
        SoundManager.instance.PlaySound("click");
        diary.SetActive(false);
        desk.GetComponent<Button>().enabled = true;
    }

    public void HideAndReveal()      //Go 버튼에 달려 있고 버튼 누르면 다이어리 숨기고 데스크 숨김.
    {                                //데스크가 다이어리 부모지만 루틴 돌 때 꼬이지 말라고 다이어리, 데스크 둘 다 비활성화
        SoundManager.instance.PlaySound("click");
        DialogueSystem.IsInAction = true;
        Debug.Log(Diary.actionList[0][0]);
        diary.SetActive(false);
        desk.SetActive(false);
        DialogueSystem.NewLoop = false;
        desk.GetComponent<Button>().enabled = true;
        

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
