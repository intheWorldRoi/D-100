using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    public static int Depress = 75;
    public static int Stress = 20;
    public static int Lonely = 20;
    public static int Anxiety = 20;
    public static int Willingness = 20;
    public static int Happyness = 20;

    //�ٽɼ�ġ
    public TextMeshProUGUI DepNum;
    public TextMeshProUGUI StrNum;
    public TextMeshProUGUI LonNum;
    public TextMeshProUGUI AnxNum;
    public TextMeshProUGUI WilNum;
    public TextMeshProUGUI HapNum;

    //���μ�ġ

    public static int Engknowledge = 1; // 1 ~ 100 ������ ��ġ, 70 �̻��Ͻ� �켱�� �������� �޼����� �س��� ���߿� ���� �ʿ�
    public static int innerpeace = 0;   //������. ���翣��
    public static int healthy = 30; // 1~100 , �ǰ���ġ

    //��¥ui
    public TextMeshProUGUI orderday;
    public TextMeshProUGUI month;
    public TextMeshProUGUI day;


    //�� ui
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
    }

    public static void DayCalculate() //��¥ ���. ������ 30�� 31�� �޶� ����ʿ� ..
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
        
        orderday.text = GameManager.Day.ToString() + "��°";
        month.text = GameManager.month.ToString() + "��";
        day.text = GameManager.monthday.ToString() + "��";
    }

}
