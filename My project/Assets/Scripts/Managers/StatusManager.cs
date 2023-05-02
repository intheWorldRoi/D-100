using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    public static int Depress, Stress, Lonely,Anxiety, Willingness, Joy;
    //핵심수치
    public TextMeshProUGUI DepNum,StrNum, LonNum, AnxNum, WilNum, joyNum;

    public RectTransform Depbar, Strbar, Lonbar, Anxbar, Wilbar, joybar;

    //세부수치

    public static int Engknowledge, innerpeace, healthy;

    public TextMeshProUGUI EngNum, innerNum, healNum;

    //날짜ui
    public TextMeshProUGUI orderday;
    public TextMeshProUGUI month;
    public TextMeshProUGUI day;
    //돈 ui
    public TextMeshProUGUI money;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Main")
        {
            Depress = 50;
            Stress = 50;
            Lonely = 50;
            Anxiety = 50;
            Willingness = 50;
            Joy = 50;

            Engknowledge = 0;
            innerpeace = 0;
            healthy = 30;
        }
        
}

    // Update is called once per frame
    void Update()
    {
        ScaleRangeStat();
        StatusIndicate();
        DayIndicate();
        ctrBar();


        money.text = GameManager.money.ToString();

    }


    private void StatusIndicate()
    {
        DepNum.text = Depress.ToString();
        StrNum.text = Stress.ToString();
        LonNum.text = Lonely.ToString();
        AnxNum.text = Anxiety.ToString();
        WilNum.text = Willingness.ToString();
        joyNum.text = Joy.ToString();

        EngNum.text = Engknowledge.ToString();
        innerNum.text = innerpeace.ToString();
        healNum.text = healthy.ToString();
    }
    public void ctrBar()
    {
        Depbar.localScale = new Vector2(Depress / 100f, 1f);
        Strbar.localScale = new Vector2(Stress / 100f, 1f);
        Lonbar.localScale = new Vector2(Lonely / 100f, 1f);
        Anxbar.localScale = new Vector2(Anxiety / 100f, 1f);
        Wilbar.localScale = new Vector2(Willingness / 100f, 1f);
        joybar.localScale = new Vector2(Joy / 100f, 1f);
    }
        public static void DayCalculate() //날짜 계산. 월별로 30일 31일 달라서 계산필요 ..
    {
        if (GameManager.month == 11 && GameManager.monthday < 31)
        {
            GameManager.monthday++;
        }
        else if (GameManager.month == 11 && GameManager.monthday > 30)
        {
            GameManager.month++;
            GameManager.monthday = 1;
        }
        else if (GameManager.month == 12 && GameManager.monthday < 32)
        {
            GameManager.monthday++;
        }
        else if (GameManager.month == 12 && GameManager.monthday > 31)
        {
            GameManager.month = 1;
            GameManager.monthday = 1;
        }
        else if (GameManager.month == 1 && GameManager.monthday < 32)
        {
            GameManager.monthday++;
        }
        else if (GameManager.month == 1 && GameManager.monthday > 31)
        {
            GameManager.month = 2;
            GameManager.monthday = 1;
        }
        else if (GameManager.month == 2 && GameManager.monthday < 29)
        {
            GameManager.monthday++;
        }
        else if (GameManager.month == 2 && GameManager.monthday > 28)
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

    private void ScaleRangeStat()
    {

        if (Stress < 0)
        {
            Stress = 0;
        }
        if (Depress < 0)
        {
            Depress = 0;
        }
        if (Lonely < 0)
        {
            Lonely = 0;
        }
        if (Anxiety < 0)
        {
            Anxiety = 0;
        }
        if (Willingness < 0)
        {
            Willingness = 0;
        }
        if (Joy < 0)
        {
            Joy = 0;
        }
        if(healthy < 0)
        {
            healthy = 0;
        }
        if (innerpeace < 0)
        {
            innerpeace = 0;
        }

        if (Depress > 100)
        {
            Depress = 100;
        }
        if(Lonely > 100)
        {
            Lonely= 100;
        }
        if(Anxiety > 100)
        {
            Anxiety= 100;
        }
        if(Stress > 100)
        {
            Stress= 100;
        }
        if (Willingness > 100)
        {
            Willingness = 100;
        }
        if (Joy > 100)
        {
            Joy = 100;
        }
        if (healthy > 100)
        {
            healthy = 100;
        }
    }

   

}
