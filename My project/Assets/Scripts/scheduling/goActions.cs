using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goActions : MonoBehaviour
{
    public static int dayIndex;                                //list[dayIndex][actionIndex] ���� ���� childindex�� ������ �̿�
    public static int actionIndex;
    public GameObject Desk, Review;
    public GameObject a;
    ActionManager actionmanager;

    public int preDep, preStr, preLon, preAnx, preWil, prejoy;
    public TextMeshProUGUI DepNum, StrNum, LonNum, AnxNum, WilNum, joyNum, healTXT, moneyTXT;

    public int preEng, preInner, preHealthy;

    public int preMoney;

    private void Awake()
    {
        actionmanager = a.GetComponent<ActionManager>();
    }
    void OnEnable()     //go ��ư Ŭ���� Ȱ��ȭ�Ǵ� ������Ʈ�Դϴ�
    {
        dayIndex = 0;
        actionIndex = 0;

        preDep = StatusManager.Depress;                         //�� �� ����, �� �� ���� �� ��ġ ����
        preStr = StatusManager.Stress;
        preLon = StatusManager.Lonely;
        preAnx = StatusManager.Anxiety;
        preWil = StatusManager.Willingness;
        prejoy = StatusManager.Joy;

        preEng = StatusManager.Engknowledge;
        preInner = StatusManager.innerpeace;
        preHealthy = StatusManager.healthy;

        preMoney = GameManager.money;

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
            reviewWeek();
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
        if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmClipsDic["main"] && SceneManager.GetActiveScene().name == "main")
        {
            SoundManager.instance.PlayBGM("main");
        }


    }
    private void MakeRent()
    {
        if (GameManager.monthday == 10)
        {
            GameManager.money -= 30;
        }
    }
    public void reviewWeek()
    {
        Review.SetActive(true);
        actionmanager.ReviewIndicate(PlusMinus(StatusManager.Depress, preDep), PlusMinus(StatusManager.Stress, preStr), PlusMinus(StatusManager.Lonely, preLon),
            PlusMinus(StatusManager.Anxiety, preAnx), PlusMinus(StatusManager.Willingness, preWil), PlusMinus(StatusManager.Joy, prejoy), PlusMinus(GameManager.money, preMoney), moneyTXT.text = PlusMinus(GameManager.money, preMoney));

        
    }
    private string PlusMinus(int stat, int preStat)
    {
        if (stat - preStat > 0)
        {
            return "+" + (stat - preStat).ToString();
        }
        else
            return (stat - preStat).ToString();
    }



    
}