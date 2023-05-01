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

    public GameObject ActionManager;

    DialogueData data;

    SoundManager s;
    private void Awake()
    {
        s = SoundManager.instance;
    }

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
        if(GameManager.Day == 99) // 99일 여기서 처리합니다
        {
            transform.parent.parent.GetChild(0).gameObject.SetActive(false); // deskimage 비활성화
            data = DialogueData.data;
            
            StartCoroutine(day99());
            for (int i = 0; i < ReviewObjects.Length; i++)
            {
                ReviewObjects[i].GetComponent<Image>().color = new Color(ReviewObjects[i].GetComponent<Image>().color.r,
                    ReviewObjects[i].GetComponent<Image>().color.g,
                    ReviewObjects[i].GetComponent<Image>().color.b, 0);
            }
            for (int i = 0; i < ReviewTexts.Length; i++)
            {
                if (i < 3)
                {
                    ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
                }
                else if (i < 12)
                {
                    ReviewTexts[i].GetComponent<TextMeshProUGUI>().text = "";
                    if (i == 11)
                    {
                        ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                    }
                }
                else if (i == 12)
                {
                    ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                }
            }
            transform.parent.GetChild(3).gameObject.SetActive(false);
            this.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            this.GetComponent<Button>().interactable = false;

            

        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            for (int i = 0; i < ReviewObjects.Length; i++)
            {
                ReviewObjects[i].GetComponent<Image>().color = new Color(ReviewObjects[i].GetComponent<Image>().color.r,
                    ReviewObjects[i].GetComponent<Image>().color.g,
                    ReviewObjects[i].GetComponent<Image>().color.b, 0);
            }
            for (int i = 0; i < ReviewTexts.Length; i++)
            {
                if (i < 3)
                {
                    ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
                }
                else if (i < 12)
                {
                    ReviewTexts[i].GetComponent<TextMeshProUGUI>().text = "";
                    if (i == 11)
                    {
                        ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                    }
                }
                else if (i == 12)
                {
                    ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                }
            }
            transform.parent.GetChild(3).gameObject.SetActive(false);
            gameObject.SetActive(false);
            s.PlayBGM("main");  

        }
        
        
    }

    public void NextBtn()
    {
        
        Debug.Log("작동");
        for (int i = 0; i < ReviewObjects.Length; i++)
        {
            ReviewObjects[i].GetComponent<Image>().color = new Color(ReviewObjects[i].GetComponent<Image>().color.r,
                ReviewObjects[i].GetComponent<Image>().color.g,
                ReviewObjects[i].GetComponent<Image>().color.b, 0);
        }
        for (int i = 0; i < ReviewTexts.Length; i++)
        {
            if (i < 3)
            {
                ReviewTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
            }
            else if(i < 12)
            {
                ReviewTexts[i].GetComponent<TextMeshProUGUI>().text = "";
            }
            
        }

        ActionManager am = ActionManager.GetComponent<ActionManager>();

        am.StartCoroutine(am.WeekDiary(GameManager.week));


        this.GetComponent<Button>().interactable = false;
    }
    public void openSetting()          
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void exit()
    {
        transform.parent.gameObject.SetActive(false);
    }
    IEnumerator day99()
    {
        yield return new WaitForSeconds(3f);
        DialogueSystem.system.Begin(data.ninetynine[0]);
        yield return new WaitForSeconds(1f);
        transform.parent.gameObject.SetActive(false);
    }
}
