using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int selectedActionItemIndex;
    static public List<List<int>> actionList = new List<List<int>>();
    bool check = false; 
    void OnEnable()
    {
        transform.GetChild(4).gameObject.SetActive(false); //실행버튼 비활성화로 초기 설정
        EpisodeChecker(GameManager.week);   //에피소드 있는 날 스케줄 편성 방지(요일 활성화 비활성화)
        selectedActionItemIndex = -1;       //인덱스를 활용하기 때문에 -1로 초기화 (초기화 안 할 시 0이 기본 값이기 때문에 아무 값 넣음)  
        
        if (actionList.Count == 0){                                 //다이어리 껐다 켜도 ㄱㅊ
            for (int i = 0; i < 7; i++)
            {
                actionList.Add(new List<int>());

                if (transform.GetChild(0).transform.GetChild(i).gameObject.activeSelf)   //요일 활성화 체크
                {
                    for(int j = 0; j < 3; j++)
                        actionList[i].Add(-1);
                }
                else
                {
                    actionList[i].Add(6);
                }
            }
        }   
        Go();                                              //플래너 껐다 켰다 해도 plan 클릭 없이 기존편성대로 go 버튼이 있어야 함
    }
    void Go()                                                    //go 버튼 활성화하는 함수 Panning 에 함수와 동일함
    {
        
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < actionList[i].Count; j++)
            {
                if (actionList[i][j] == -1)
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
            transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    public void EpisodeChecker(int week)                                        //에피소드 처리
    {
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(true);

        transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(false);

        switch (week)
        {
            case 5:
                transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
                transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 9:
                transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
                break ;
            case 11:
                transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
                transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
