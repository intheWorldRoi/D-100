using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{

    StatusManager manager;
    public static int NowActionIndex;
    public static int NowDayIndex;

    //public static string readingBook;

    public static bool PNP() {
        if (StatusManager.Stress > 70 || StatusManager.Willingness < 40 || StatusManager.Happyness < 40)
            return false;
        else
            return true;
    }

    public static bool SNS()
    {
        if (StatusManager.Depress > 50 && StatusManager.Willingness < 50)      //우울하고 의지 없을 시 SNS
        {
            StatusManager.innerpeace -= 10;
            return true;
        }
        else
            return false;
    }
    public static void Toeic(bool pass)
    {
        if (pass)
        {
            StatusManager.Engknowledge += 2;
            StatusManager.Happyness -= 5;
            StatusManager.Anxiety -= 3;
            StatusManager.Stress += 2 + (int)(0.1 * (StatusManager.Anxiety));
        }
        else {
            StatusManager.Engknowledge += 1;
            StatusManager.Happyness -= 5;
            StatusManager.Anxiety -= 1;
            StatusManager.Stress += 2 + (int)(0.1 * (StatusManager.Anxiety));
        }
    }
    public static void Fitness(bool pass)
        {
            if (pass) {
                StatusManager.healthy += 3;
                StatusManager.Willingness += 3;
                StatusManager.Depress -= 3;
                StatusManager.Stress += 3;
            }
            else{
                StatusManager.healthy += 1;
                StatusManager.Depress -= 3;
                StatusManager.Stress += 3;
            }
        }
    public static void Reading(int index)
    {
        switch (index) {
            case 0:
                {
                    StatusManager.Anxiety += 5;
                    StatusManager.Willingness += 5;
                    StatusManager.Happyness -= 3;
                    break;
                }
            case 1:
                {
                    StatusManager.Depress -= (int)(5 * (StatusManager.Stress / 100 * StatusManager.Happyness / 10));
                    break;
                }
            case 2:
                {
                    StatusManager.Happyness += (int)(5 * StatusManager.Stress / 100 * StatusManager.Willingness / 10);
                    break;
                }
        }
    }

    public static void Rest()
    {
        if (StatusManager.Anxiety > 60)
        {
            StatusManager.Stress -= 3;
            StatusManager.Depress -= 2;
            StatusManager.Anxiety -= 2;
        }
        else if (StatusManager.Anxiety > 40 && StatusManager.Depress > 30)
        {
            StatusManager.Stress -= 5;
            StatusManager.Depress -= 4;
            StatusManager.Anxiety -= 3;
        }
        else if (StatusManager.Stress > 70)
        {
            StatusManager.Stress -= 3;
            StatusManager.Depress -= 5;
            StatusManager.Anxiety -= 6;
        }
        else
        {
            StatusManager.Stress -= 10;
            StatusManager.Depress -= 3;
            StatusManager.Anxiety += 3;
            StatusManager.Happyness += 5;
        }
    }

    public static void GoOut()
    {
        if (StatusManager.Anxiety > 60)
        {
            StatusManager.Stress -= 3;
            StatusManager.Depress -= 2;
            StatusManager.Anxiety -= 2;
        }
        else if (StatusManager.Anxiety > 40 && StatusManager.Depress > 30)
        {
            StatusManager.Stress -= 5;
            StatusManager.Depress -= 4;
            StatusManager.Anxiety -= 3;
        }
        else if (StatusManager.Stress > 70)
        {
            StatusManager.Stress -= 3;
            StatusManager.Depress -= 5;
            StatusManager.Anxiety -= 6;
        }
        else
        {
            StatusManager.Stress -= 10;
            StatusManager.Depress -= 3;
            StatusManager.Anxiety += 3;
            StatusManager.Happyness += 5;
        }
    }

    public static void Partjob(bool pass)
    {
        GameManager.money += 10;
        StatusManager.Stress += (int)(3 * StatusManager.Stress / 10);
    }

    public static void HowAreYou()
    {
        StatusManager.Lonely += 3;
        StatusManager.Anxiety += 3;

        if (StatusManager.healthy < 20)             //건강에 따라 의지와 즐거움 변화
        {
            StatusManager.Willingness -= 5;
            StatusManager.Happyness -= 5;
        }
        if (StatusManager.Stress >50 || StatusManager.Lonely > 30)
        {
            StatusManager.Depress += 3;
        }
        if (StatusManager.Happyness < 40)
        {
            StatusManager.Willingness -= 3;
        }
        if(StatusManager.Stress > 50)
        {
            StatusManager.healthy -= 3;
        }

    }
}
