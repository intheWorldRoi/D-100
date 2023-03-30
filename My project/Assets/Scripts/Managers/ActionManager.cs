using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{

    StatusManager manager;

    public static string readingBook;


    public static void Toeic()
    {
        StatusManager.Engknowledge += 3 * (int)(StatusManager.focus * (StatusManager.Stress / 100) * StatusManager.Willingness); // 영어 지식이 집중력 * (0.01 * 스트레스) * 의지에 따라 누적
        StatusManager.Happyness -= 5; //즐거움 5 감소
        StatusManager.Stress += (int)(0.003 * (StatusManager.Anxiety * StatusManager.Depress)); // 우울 * 불안 * 0.003 만큼 스트레스 증가
        
    }

    public static void Fitness()
    {
        StatusManager.healthy += 5 * (int)(StatusManager.focus * (StatusManager.Stress / 100) * StatusManager.Willingness); //건강이 집중력 * 스트레스 /100 * 의지에 따라 증가
    }

    public static void Reading()
    {
        if (readingBook == "자기계발서")
        {
            StatusManager.Anxiety += 5;
            StatusManager.Willingness += 5;
            StatusManager.Happyness -= 3;
        }
        else if (readingBook == "에세이")
        {
            StatusManager.Depress -= (int)(5 * (StatusManager.Stress / 100 * StatusManager.Happyness / 10));
        }
        else if (readingBook == "소설")
        {
            StatusManager.Happyness += (int)(5 * StatusManager.Stress / 100 * StatusManager.Willingness /10);
        }
    }

    public static void Rest()
    {
        StatusManager.Anxiety += 5;
        StatusManager.Willingness += 5;
        StatusManager.Happyness += 5; // 근데 쉴 때 행복 증가하는것도 스트레스에 영향을 받아야하나...?ㅋㅋㅋㅋㅋㅋㅋ    
    }

    public static void GoOut()
    {

    }

    public static void Partjob()
    {
        GameManager.money += 50000;
        StatusManager.Stress += (int)(3 * StatusManager.Stress / 10);
    }

    
}
