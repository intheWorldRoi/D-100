using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public int selectedActionItemIndex;
    public int[][] actionList;
    public Queue<int> dayPlan = new Queue<int>();
    public Queue<Queue<int>> weekPlan = new Queue<Queue<int>>();
    void OnEnable()
    {
        transform.GetChild(4).gameObject.SetActive(false); //실행버튼 비활성화로 초기 설정
        EpisodeChecker(GameManager.week);   //에피소드 있는 날 스케줄 편성 방지(요일 활성화 비활성화)
        selectedActionItemIndex = -1;       //인덱스를 활용하기 때문에 -1로 초기화 (초기화 안 할 시 0이 기본 값이기 때문에 아무 값 넣음)  
        actionList = new int[7][];          //일주일 7일. 하루당 행동 3개가 기본, 그러나 에피소드시 행동 1개

        for (int i = 0; i < 7; i++)         
        {
            if (transform.GetChild(0).transform.GetChild(i).gameObject.activeSelf)   //요일 활성화 체크
            {
                actionList[i] = new int[] { -1, -1, -1 };
            }
            else
            {
                actionList[i] = new int[] { -1 };
            }
        }
    }
    public void EpisodeChecker(int week)
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
