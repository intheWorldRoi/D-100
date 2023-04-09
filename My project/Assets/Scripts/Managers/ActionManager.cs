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
        if (StatusManager.Stress > 75 || StatusManager.Willingness < 25 || StatusManager.Happyness < 25)
            return false;
        else
            return true;
    }

    public static bool SNS()
    {
        if (StatusManager.Depress > 60 && StatusManager.Willingness < 40)      //우울하고 의지 없을 시 SNS
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
            StatusManager.Engknowledge += 3;
            StatusManager.Happyness -= 3;
            StatusManager.Anxiety -= 3;
            StatusManager.Stress += 3;
        }
        else {
            StatusManager.Engknowledge += 1;
            StatusManager.Happyness -= 3;
            StatusManager.Anxiety -= 1;
            StatusManager.Stress += 3;
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
                StatusManager.Depress -= 1;
                StatusManager.Stress += 3;
            }
        }
    public static void Reading(int index)
    {
        StatusManager.Stress += 3;
        StatusManager.innerpeace += 3;
        switch (index) {
            case 0:
                {
                    StatusManager.Anxiety += 5;
                    StatusManager.Willingness += 10;
                    break;
                }
            case 1:
                {
                    StatusManager.Depress -= 10;
                    break;
                }
            case 2:
                {
                    StatusManager.Happyness += 10;
                    break;
                }
        }
    }

    public static void Rest()
    {
        if (StatusManager.Anxiety > 75)
        {
            StatusManager.Stress -= 1;
            StatusManager.Depress -= 1;
            StatusManager.Happyness += 1;
        }
        else
        {
            StatusManager.Stress -= 10;
            StatusManager.Depress -= 3;
            StatusManager.Happyness += 3;
        }
        StatusManager.Anxiety += 3;
    }

    public static void GoOut()
    {
        if (StatusManager.Anxiety > 75)
        {
            StatusManager.Depress -= 3;
            StatusManager.Anxiety -= 5;
        }
        else if (StatusManager.Depress > 75)
        {
            StatusManager.Depress -= 5;
            StatusManager.Anxiety -= 3;
        }
        else
        {
            StatusManager.Depress -= 3;
            StatusManager.Anxiety -= 3;
            StatusManager.Happyness += 5;
        }
        StatusManager.Stress -= 5;
        StatusManager.Lonely -= 10;
    }

    public static void Partjob(bool pass)
    {
        GameManager.money += 5;
        StatusManager.Stress += 5;
    }

    public static void HowAreYou()
    {
        StatusManager.Lonely += 3;
        StatusManager.Anxiety += 3;

        if (StatusManager.healthy < 25)             //건강에 따라 의지와 즐거움 변화
        {
            StatusManager.Willingness -= 3;
            StatusManager.Happyness -= 3;
        }
        if (StatusManager.Stress >50 || StatusManager.Lonely > 75)
        {
            StatusManager.Depress += 3;
        }
        if (StatusManager.Happyness < 25)
        {
            StatusManager.Willingness -= 3;
        }
        if (StatusManager.Happyness > 75)
        {
            StatusManager.Willingness += 3;
        }
        if (StatusManager.Stress > 50)
        {
            StatusManager.healthy -= 3;
        }

    }
}
