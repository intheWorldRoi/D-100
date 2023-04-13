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
        if (StatusManager.Stress > 70 || StatusManager.Willingness < 40 || StatusManager.Joy < 40)
            return false;
        else
            return true;
    }

    public static bool SNS()
    {
        if (StatusManager.Depress > 55 && StatusManager.Willingness < 45)      //우울하고 의지 없을 시 SNS
        {
            StatusManager.Lonely += 3;
            StatusManager.Anxiety += 5;
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
            StatusManager.Engknowledge += 5;
            StatusManager.Joy -= 2;
            StatusManager.Anxiety -= 3;
            StatusManager.Stress += 3;
        }
        else {
            StatusManager.Engknowledge += 3;
            StatusManager.Joy -= 5;
            StatusManager.Anxiety -= 1;
            StatusManager.Stress += 3;
        }
    }
    public static void Fitness(bool pass)
        {
            if (pass) {
                StatusManager.healthy += 5;
                StatusManager.Willingness += 3;
                StatusManager.Depress -= 3;
                StatusManager.Stress += 3;
                StatusManager.Joy += 2;
            }
            else{
                StatusManager.healthy += 2;
                StatusManager.Willingness += 1;
                StatusManager.Depress -= 1;
                StatusManager.Stress += 3;
            }
        }
    public static void Reading(int index)
    {
        StatusManager.Stress += 3;
        switch (index) {
            case 0:
                {
                    StatusManager.Anxiety += 5;
                    StatusManager.Willingness += 10;
                    StatusManager.innerpeace += 3;
                    if (StatusManager.Willingness < 30)
                    {
                        StatusManager.Willingness += 20;
                    }
                    break;
                }
            case 1:
                {
                    StatusManager.Anxiety -= 10;
                    StatusManager.Depress -= 5;
                    StatusManager.innerpeace += 3;
                    
                    break;
                }
            case 2:
                {
                    StatusManager.Anxiety -= 3;
                    StatusManager.Joy += 5;
                    StatusManager.innerpeace += 5;
                    StatusManager.Depress -= 5;
                    break;
                }
        }
    }

    public static void Rest()
    {

        if(StatusManager.Stress > 80)
        {
            StatusManager.Stress -= 40;
        }
        else if(StatusManager.Stress > 70)
        {
            StatusManager.Stress -= 30;
        }
        else if (StatusManager.Stress > 60)
        {
            StatusManager.Stress -= 20;
        }
        else if (StatusManager.Anxiety > 70)
        {
            StatusManager.Stress -= 1;
            StatusManager.Depress -= 1;
            StatusManager.Joy += 3;
        }
        else
        {
            StatusManager.Stress -= 15;
            StatusManager.Depress -= 3;
            StatusManager.Joy += 10;
        }
        StatusManager.Anxiety += 3;
        StatusManager.Lonely += 3;
        StatusManager.Willingness -= 3;
    }

    public static void GoOut()
    {
        if (StatusManager.Anxiety > 70)
        {
            StatusManager.Anxiety -= 25;
        }
        if (StatusManager.Depress > 70)
        {
            StatusManager.Depress -= 25;
        }
        else
        {
            StatusManager.Depress -= 3;
            StatusManager.Anxiety -= 3;
            StatusManager.Joy += 3;
        }
        if(StatusManager.Lonely > 70)
        {
            StatusManager.Lonely -= 10;
        }
        StatusManager.Stress -= 3;                // ????
        StatusManager.Lonely -= 10;
        StatusManager.innerpeace += 3;
        GameManager.money -= 1;
    }

    public static void Partjob()
    {
        StatusManager.Stress += 5;
        StatusManager.Joy -= 3;
        StatusManager.Lonely -= 1;
        StatusManager.Anxiety -= 1;
        StatusManager.healthy -= 1;
        GameManager.money += 10;
    }

    public static void HowAreYou()
    {
        StatusManager.Lonely += 5;
        StatusManager.Anxiety += 5;

        if (StatusManager.healthy < 50)
        {
            StatusManager.Depress += 3;
            StatusManager.Willingness -= 3;
            StatusManager.Joy -= 3;
        }


        if (StatusManager.Lonely > 50)
        {
            StatusManager.Depress += 3;
            StatusManager.Joy -= 3;
        }


        if (StatusManager.Joy < 50 || StatusManager.Depress >50)
        {
            StatusManager.Willingness -= 3;
        }

        if (StatusManager.Anxiety > 70)
        {
            StatusManager.Willingness +=10;
            StatusManager.Stress += 5;
            StatusManager.innerpeace -= 5;
        }
        else if(StatusManager.Anxiety > 60)
        {
            StatusManager.Willingness += 5;
            StatusManager.Depress += 3;
            StatusManager.Stress += 3;
            StatusManager.innerpeace -= 3;
        }
        else if(StatusManager.Anxiety>50)
        {
            StatusManager.Willingness += 3;
            StatusManager.Depress += 3;
            StatusManager.Stress += 1;
            StatusManager.innerpeace -= 1;
        }


        if (StatusManager.Stress > 70)
        {
            StatusManager.Depress += 5;
            StatusManager.healthy -= 3;
        }

        else if (StatusManager.Stress > 50)
        {
            StatusManager.Depress += 3;
            StatusManager.healthy -= 2;
        }
        else
        {
            StatusManager.Depress += 1;
            StatusManager.healthy -= 1;
        }

        if(StatusManager.innerpeace > 50)
        {
            StatusManager.Anxiety -= 1;
        }
        else if(StatusManager.innerpeace > 100)
        {
            StatusManager.Anxiety -= 3;
        }
        else if(StatusManager.innerpeace > 150)
        {
            StatusManager.Anxiety -= 5;
        }
    }
}
