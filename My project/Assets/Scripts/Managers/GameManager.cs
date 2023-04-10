using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static int Day = 1; //며칠이나 지났나
    public static int month = 11; //월
    public static int monthday = 22; //일

    public static string TODAY; // 오늘은 무슨 요일인
    public static int week =1; // 몇번째 주 인가

    public static int money = 30;


    public static void EndingCheck()
    {
        if(StatusManager.Anxiety >= 100 || StatusManager.Depress >= 100 || StatusManager.Stress >= 100 || StatusManager.Lonely >= 100)
        {
            SceneManager.LoadScene(1);
        }
    }
}
