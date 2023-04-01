using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{

    StatusManager manager;

    //public static string readingBook;


    public static void Toeic()
    {
        StatusManager.Engknowledge += 3 * (int)(StatusManager.focus * (StatusManager.Stress / 100) * StatusManager.Willingness); // 慎嬢 走縦戚 増掻径 * (0.01 * 什闘傾什) * 税走拭 魚虞 刊旋
        StatusManager.Happyness -= 5; //荘暗崇 5 姶社
        StatusManager.Stress += (int)(0.003 * (StatusManager.Anxiety * StatusManager.Depress)); // 酔随 * 災照 * 0.003 幻鏑 什闘傾什 装亜
        
    }

    public static void Fitness()
    {
        StatusManager.healthy += 5 * (int)(StatusManager.focus * (StatusManager.Stress / 100) * StatusManager.Willingness); //闇悪戚 増掻径 * 什闘傾什 /100 * 税走拭 魚虞 装亜
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
        StatusManager.Anxiety += 5;
        StatusManager.Willingness += 5;
        StatusManager.Happyness += 5; // 悦汽 蒐 凶 楳差 装亜馬澗依亀 什闘傾什拭 慎狽聖 閤焼醤馬蟹...?せせせせせせせ    
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
