using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    public static int Depress = 50;
    public static int Stress = 50;
    public static int Lonely = 50;
    public static int Anxiety = 50;
    public static int Willingness = 50;
    public static int Happyness = 50;

    //핵심수치
    public TextMeshProUGUI DepNum;
    public TextMeshProUGUI StrNum;
    public TextMeshProUGUI LonNum;
    public TextMeshProUGUI AnxNum;
    public TextMeshProUGUI WilNum;
    public TextMeshProUGUI HapNum;

    //세부수치

    public static int Engknowledge = 0; // 1 ~ 100 까지의 수치, 70 이상일시 우선은 도전과제 달성으로 해놓고 나중에 밸패 필요
    public static int innerpeace = 0;   //깨달음. 히든엔딩
    public static int healthy = 30; // 1~100 , 건강수치

    public TextMeshProUGUI EngNum;
    public TextMeshProUGUI innerNum;
    public TextMeshProUGUI healNum;

    //날짜ui
    public TextMeshProUGUI orderday;
    public TextMeshProUGUI month;
    public TextMeshProUGUI day;


    //돈 ui
    public TextMeshProUGUI money;



    // Update is called once per frame
    void Update()
    {
        StatusIndicate();
        DayIndicate();
        money.text = GameManager.money.ToString();
    }


    private void StatusIndicate()
    {
        DepNum.text = Depress.ToString();
        StrNum.text = Stress.ToString();
        LonNum.text = Lonely.ToString();
        AnxNum.text = Anxiety.ToString();
        WilNum.text = Willingness.ToString();
        HapNum.text = Happyness.ToString();

        EngNum.text = Engknowledge.ToString();
        innerNum.text = innerpeace.ToString();
        healNum.text = healthy.ToString();
    }

    public static void DayCalculate() //날짜 계산. 월별로 30일 31일 달라서 계산필요 ..
    {
        if (GameManager.month == 11 && GameManager.monthday < 30)
        {
            GameManager.monthday++;
        }
        else if (GameManager.month == 11 && GameManager.monthday == 30)
        {
            GameManager.month++;
            GameManager.monthday = 1;
        }
        else if ((GameManager.month == 12 || GameManager.monthday == 1) && GameManager.monthday < 31)
        {
            GameManager.monthday++;
        }
        else if ((GameManager.month == 12 || GameManager.monthday == 1) && GameManager.monthday == 31)
        {
            GameManager.month++;
            GameManager.monthday = 1;
        }
        else if (GameManager.month == 2 && GameManager.monthday < 28)
        {
            GameManager.monthday++;
        }
        else if (GameManager.month == 2 && GameManager.monthday == 28)
        {
            GameManager.month++;
            GameManager.monthday = 1;
        }
    }
    private void DayIndicate()
    {
        
        orderday.text = GameManager.Day.ToString() + "일째";
        month.text = GameManager.month.ToString() + "월";
        day.text = GameManager.monthday.ToString() + "일";
    }

}
