using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{

    StatusManager manager;

    //public static string readingBook;

    public bool PNP() {
        if (StatusManager.Stress > 70 || StatusManager.Willingness < 40 || StatusManager.Happyness < 40)
            return false;
        else
            return true;
    }

    public bool SNS()
    {
        if (StatusManager.healthy < 20)             //�ǰ��� ���� ������ ��ſ� ��ȭ
        {
            StatusManager.Willingness -= 3;
            StatusManager.Happyness -= 3;
        }
        if (StatusManager.Depress > 50 && StatusManager.Willingness < 50)      //����ϰ� ���� ���� �� SNS
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
                StatusManager.Depress -= 5;
                StatusManager.Stress += 3;
            }
            else{
                StatusManager.healthy += 1;
                StatusManager.Depress -= 5;
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

    public static void Rest(bool pass)
    {
        StatusManager.Stress -= 20;
        StatusManager.Depress -= 3;
        StatusManager.Anxiety += 5;
        StatusManager.Happyness += 5;  
    }

    public static void GoOut()
    {

    }

    public static void Partjob(bool pass)
    {
        GameManager.money += 50000;
        StatusManager.Stress += (int)(3 * StatusManager.Stress / 10);
    }

    
}