using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class goActions : MonoBehaviour
{
    public static int dayIndex;                                //list[dayIndex][actionIndex] 접근 값이 childindex와 같음을 이용
    public static int actionIndex;
    public GameObject Desk;

    

    void OnEnable()
    {
        dayIndex = 0;                                   //go 버튼 클릭시 활성화되는 오브젝트입니
        actionIndex = 0;
        transform.GetChild(Diary.actionList[0][0]).gameObject.SetActive(true);
        
        ActionManager.NowActionIndex = 0;
    }
    public void nextPlay()                              //스케줄의 연쇄적 실행 
    {
        
        ActionManager.NowActionIndex += 1;
        transform.GetChild(Diary.actionList[dayIndex][actionIndex++]).gameObject.SetActive(false);    //전 스케줄 종료
        if (actionIndex == Diary.actionList[dayIndex].Count)                                          //하루치 액션을 다 수행했는지
        {
            GameManager.EndingCheck();

            MakeRent();
            ActionManager.HowAreYou();
            actionIndex = 0;
            dayIndex++;
            GameManager.Day++;
            StatusManager.DayCalculate();
        }
        if (dayIndex == 7)                                                            //일주일치 액션을 다 수행했는지
        {

            GameManager.week++;
            gameObject.SetActive(false);                                              //스케줄 1주일치 완료시 스스로 비활성화로 루틴 1 종료
            Desk.SetActive(true);
            Diary.actionList.Clear();
            DialogueSystem.IsInAction = false;
            DialogueSystem.NewLoop = true;
            if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmClipsDic["main"])
            {
                SoundManager.instance.PlayBGM("main");
            }
            return;
        }
        
        transform.GetChild(Diary.actionList[dayIndex][actionIndex]).gameObject.SetActive(true);         //다음 스케줄 활성화
        if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmClipsDic["main"])
        {
            SoundManager.instance.PlayBGM("main");
        }


    }
    private void MakeRent()
    {
        if(GameManager.monthday == 10)
        {
            GameManager.money -= 30;
        }
    }
}
