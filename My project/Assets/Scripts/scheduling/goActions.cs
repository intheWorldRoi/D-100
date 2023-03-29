using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goActions : MonoBehaviour
{
    public int dayIndex;                                //list[dayIndex][actionIndex] 접근 값이 childindex와 같음을 이용
    public int actionIndex;
    public GameObject Desk;

    

    void OnEnable()
    {
        dayIndex = 0;                                   //go 버튼 클릭시 활성화되는 오브젝트입니
        actionIndex = 0;
        //transform.GetChild(0).gameObject.SetActive(true);
    }
    public void nextPlay()                              //스케줄의 연쇄적 실행 
    {
        transform.GetChild(Diary.actionList[dayIndex][actionIndex++]).gameObject.SetActive(false);    //전 스케줄 종료
        if (actionIndex == Diary.actionList[dayIndex].Count)                                          //하루치 액션을 다 수행했는지
        {
            actionIndex = 0;
            dayIndex++;
            GameManager.Day++;
            StatusManager.DayCalculate();
            StatusManager.Lonely += 3;
        }
        if (dayIndex == 7)                                                            //일주일치 액션을 다 수행했는지
        {   GameManager.week++;
            gameObject.SetActive(false);                                              //스케줄 1주일치 완료시 스스로 비활성화로 루틴 1 종료
            Desk.SetActive(true);
            Diary.actionList.Clear();
        }
        
        transform.GetChild(Diary.actionList[dayIndex][actionIndex]).gameObject.SetActive(true);         //다음 스케줄 활성화
        switch (Diary.actionList[dayIndex][actionIndex])
        {
            case 0:
                ActionManager.Toeic();
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1: 
                ActionManager.Fitness();
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                ActionManager.Reading();
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                ActionManager.Rest();
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 4:
                ActionManager.GoOut();
                gameObject.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 5:
                ActionManager.Partjob();
                gameObject.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }
    }
}

/*private void OnEnable()
 {
     StartCoroutine(perform(Diary.actionList));
 }
 IEnumerator perform (List<List<int>> actionList)
 {
     for (int i = 0; i < actionList.Count; i++)
     {
         for(int j = 0; j < actionList[i].Count; j++)
         {
             transform.GetChild(actionList[i][j]).gameObject.SetActive(true);
             yield return new WaitForSeconds(2.0f);
         }
     }
 }*/