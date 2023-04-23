using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class goActions : MonoBehaviour
{
    public static int dayIndex;                                //list[dayIndex][actionIndex] ���� ���� childindex�� ������ �̿�
    public static int actionIndex;
    public GameObject Desk;

    

    void OnEnable()
    {
        dayIndex = 0;                                   //go ��ư Ŭ���� Ȱ��ȭ�Ǵ� ������Ʈ�Դ�
        actionIndex = 0;
        transform.GetChild(Diary.actionList[0][0]).gameObject.SetActive(true);
        
        ActionManager.NowActionIndex = 0;
    }
    public void nextPlay()                              //�������� ������ ���� 
    {
        
        ActionManager.NowActionIndex += 1;
        transform.GetChild(Diary.actionList[dayIndex][actionIndex++]).gameObject.SetActive(false);    //�� ������ ����
        if (actionIndex == Diary.actionList[dayIndex].Count)                                          //�Ϸ�ġ �׼��� �� �����ߴ���
        {
            GameManager.EndingCheck();

            MakeRent();
            ActionManager.HowAreYou();
            actionIndex = 0;
            dayIndex++;
            GameManager.Day++;
            StatusManager.DayCalculate();
        }
        if (dayIndex == 7)                                                            //������ġ �׼��� �� �����ߴ���
        {

            GameManager.week++;
            gameObject.SetActive(false);                                              //������ 1����ġ �Ϸ�� ������ ��Ȱ��ȭ�� ��ƾ 1 ����
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
        
        transform.GetChild(Diary.actionList[dayIndex][actionIndex]).gameObject.SetActive(true);         //���� ������ Ȱ��ȭ
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
