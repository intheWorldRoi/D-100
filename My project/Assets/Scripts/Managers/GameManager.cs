using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static int Day = 1; //¸çÄ¥ÀÌ³ª Áö³µ³ª
    public static int month = 11; //¿ù
    public static int monthday = 22; //ÀÏ

    public static string TODAY; // ¿À´ÃÀº ¹«½¼ ¿äÀÏÀÎ
    public static int week =1; // ¸î¹øÂ° ÁÖ ÀÎ°¡

    public static int money = 30;


    public static void EndingCheck()
    {
        if(StatusManager.Anxiety >= 100 || StatusManager.Depress >= 100 || StatusManager.Stress >= 100 || StatusManager.Lonely >= 100)
        {
            SceneManager.LoadScene(1);
        }
        if(money < 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void Update()
    {
        if(Day == 100)
        {
            if(StatusManager.innerpeace > 80 && StatusManager.Engknowledge > 100 && StatusManager.healthy > 80)
            {
                //Âð¿£µù¾À ºÎ¸£±â
            }
            
        }
    }
}
